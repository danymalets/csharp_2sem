﻿using System;
using System.Collections.Generic;

namespace HumanProject
{
    public enum Genders
    {
        Male,
        Female
    }

    public class Human : IComparable<Human>
    {
        public delegate void SameSexMarriageHandler(Genders gender);
        static public event SameSexMarriageHandler SameSexMarriageEvent;

        public delegate void DivorceHandler();
        static public event DivorceHandler DivorceEvent;

        public string FullName { get; private set; }
        public string Identifier { get; private set; }
        public Genders Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Human Partner { get; private set; }
        public Human Mother { get; private set; }
        public Human Father { get; private set; }
        public List<Human> Children = new List<Human>();

        public Human()
        {
            FullName = "-";
            Identifier = "-";
            Gender = Genders.Male;
            DateOfBirth = DateTime.Now;
        }

        public Human(string fullName, string identifier)
        {
            FullName = fullName;
            Identifier = identifier;
            Gender = Genders.Male;
            DateOfBirth = DateTime.Now;
        }

        public Human(string fullName, string identifier, Genders gender)
        {
            FullName = fullName;
            Identifier = identifier;
            Gender = gender;
            DateOfBirth = DateTime.Now;
        }

        public Human(string fullName, string identifier, Genders gender,
            DateTime dateOfBirth, Human mother, Human father)
        {
            FullName = fullName;
            Identifier = identifier;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Mother = mother;
            Father = father;
            if (Mother != null) Mother.AddChild(this);
            if (Father != null) Father.AddChild(this);
        }

        void AddChild(Human child)
        {
            Children.Add(child);
        }

        void RemoveChild(Human child)
        {
            Children.Remove(child);
        }

        public bool SetParent(Human parent)
        {
            if (parent.Gender == Genders.Male)
            {
                if (Father != null) return false;
                Father = parent;
            }
            else
            {
                if (Mother != null) return false;
                Mother = parent;
            }
            parent.AddChild(this);
            return true;
        }

        public override string ToString()
        {
            string res = "";
            int age = GetAge(DateOfBirth);
            res += $"{FullName}, id = {Identifier}, {age}";
            if (age == 1) res += " year, "; else res += " years, ";
            if (Gender == Genders.Male) res += "Male\n"; else res += "Female\n";
            if (Gender == Genders.Male)
            {
                if (Partner == null) res += "no wife";
                else res += $"Wife - {Partner.FullName} [id={Partner.Identifier}] ";
            }
            else
            {
                if (Partner == null) res += "no husband";
                else res += $"Husband - {Partner.FullName} [id={Partner.Identifier}] ";
            }
            res += ", ";
            if (Mother == null) res += "no mother"; else res += $"Mother - {Mother.FullName} [id={Mother.Identifier}]";
            res += ", ";
            if (Father == null) res += "no father"; else res += $"Father - {Father.FullName} [id={Father.Identifier}]";
            res += "\n";
            if (Children.Count == 0) res += "no children"; else res += "Children list:\n";
            for (int i = 0; i < Children.Count; i++)
            {
                res += $"{i + 1}) {Children[i].FullName} [id={Children[i].Identifier}]\n";
            }
            return res;
        }

        public int CompareTo(Human human)
        {
            return -DateOfBirth.CompareTo(human.DateOfBirth);
        }

        public static bool Marriage(Human human1, Human human2)
        {
            if (human1.Gender == human2.Gender)
            {
                SameSexMarriageEvent?.Invoke(human1.Gender);
                return false;
            }
            human1.Partner = human2;
            human2.Partner = human1;
            return true;
        }

        public void Divorce()
        {
            Partner.Partner = null;
            Partner = null;
            DivorceEvent?.Invoke();
        }

        public static int GetAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear) age--;
            return age;
        }

        public void Delete()
        {
            if (Partner != null) Partner.Partner = null;
            if (Mother != null) Mother.RemoveChild(this);
            if (Father != null) Father.RemoveChild(this);
            if (Gender == Genders.Male)
            {
                foreach (var child in Children)
                {
                    child.Father = null;
                }
            }
            else
            {
                foreach (var child in Children)
                {
                    child.Mother = null;
                }
            }
        }
    }
}

