﻿// dllmain.cpp : Определяет точку входа для приложения DLL.
#include "pch.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    srand(time(NULL));
    srand(rand() % 1000);
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

