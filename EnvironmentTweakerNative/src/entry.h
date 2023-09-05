#ifndef ENTRY_H
#define ENTRY_H
#include <cstdio>

#ifdef CPLUSPLUS
extern "C"
{
#endif

    __declspec(dllexport) void hello_func();
#ifdef CPLUSPLUS
}
#endif
#endif