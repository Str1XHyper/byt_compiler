.386
.model flat,stdcall
.stack 4096
option casemap :none

include \masm32\include\kernel32.inc
include \masm32\include\masm32.inc
includelib \masm32\lib\kernel32.lib
includelib \masm32\lib\masm32.lib

.code
main:
    invoke ExitProcess, 420
end main