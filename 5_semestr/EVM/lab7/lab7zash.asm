ADI 80
LXI H, 08F0
MOV M, A
XRA A
ADI 01
INX H
MOV M, A

LDA 08FF
MOV C, A
begz:
LXI H, 08FF
MOV A, L
ADD C
INR H
MOV L, A
MOV A, M
MOV D, A
LXI H, 08F0

MOV E, M
ANA E
JPE movedz
INR B
LXI H, 08FF
MOV A, L
ADD M
ADD B
INR H

JNC skz
INR H
skz:
MOV L, A
MOV M, D
movedz:
DCR C
JNZ begz

LXI H, 08FE
MOV M, B


sEven:
LXI H, 08FE
MOV C, M

nextE:

LDA 08FF
MOV D, A
LXI H, 08FF
MOV A, L
ADD D
INR H
INR A
MOV L, A

mov d,c
moveE: mov a,m
inx h
sub m
jnc endifE
add m
mov b,m
mov m,a
dcx h
mov m,b
inx h
endifE: dcr d
jnz moveE
dcr c
jnz nextE

gainingEven:
XRA A
MOV B, A

LDA 08FF
MOV C, A
bege:
LXI H, 08FF
MOV A, L
ADD C
INR H
MOV L, A
MOV A, M
MOV D, A

LXI H, 08F0
MOV E, M
ANA E
JPO movede

LXI H, 08F1

MOV E, M
MOV A, D
ANA E
JPO movede
INR B
LXI H, 08FF
MOV A, L
ADD M
ADD B
LXI H, 08FE
ADD M
INR H

JNC ske
INR H
ske:
MOV L, A
MOV M, D
movede:
DCR C
JNZ bege

LXI H, 08FD
MOV M, B

gainingOdd:
XRA A
MOV B, A

LDA 08FF
MOV C, A
bego:
LXI H, 08FF
MOV A, L
ADD C
INR H
MOV L, A
MOV A, M
MOV D, A

LXI H, 08F0
MOV E, M
ANA E
JPO movedo

LXI H, 08F1

MOV E, M
MOV A, D
ANA E
JPE movedo
INR B
LXI H, 08FF
MOV A, L
ADD M
ADD B
LXI H, 08FE
ADD M
LXI H, 08FD
ADD M
INR H

JNC sko
INR H
sko:
MOV L, A
MOV M, D
movedo:
DCR C
JNZ bego

LXI H, 08FC
MOV M, B

HLT
