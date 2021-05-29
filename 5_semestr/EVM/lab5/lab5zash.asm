LXI H, 0B04
MOV A, M
RAR
JNC nocai
INR B
nocai: ;без переноса в старшем разряде A
;ANI 7F ;обнуление старшего бита
LXI H, 0B14
MOV M, A

LXI H, 0B02 ;деление второго байта
MOV C, M
XRA A
MOV A, B
RAR

MOV E, A

XRA A ;
MOV B, A ;обнуление B

MOV A, C
RAR
JNC nocaid
INR B
nocaid: ;без переноса в среднем разряде A
;ANI 7F ;обнуление старшего бита
ORA E
LXI H, 0B12
MOV M, A


LXI H, 0B00 ;деление третьего байта
MOV C, M

MOV A, B
RRC

MOV E, A

XRA A ;
MOV B, A ;обнуление B

MOV A, C
RAR
JNC nocait
INR B
nocait: ;без переноса в среднем разряде A
;ANI 7F ;обнуление старшего бита
ORA E
LXI H, 0B10
MOV M, A

;деление D
LXI H, 0B0B
MOV A, M
RAR
JNC nocdii
INR B
nocdii: ;отсутствие переноса при делении на 2
MOV E, A
MOV A, B
RRC
MOV B, A
MOV A, E

ANI 7F ;обнеление старшего бита

RAR
JNC nocdid
INR B
nocdid: ;отсутствие переноса при делении на 2
MOV E, A
MOV A, B
RRC
MOV B, A
MOV A, E
;nocdid: ;без переноса в старшем разряде A
ANI 7F ;обнеление старшего бита

LXI H, 0B1B
MOV M, A

LXI H, 0B0A ;деление второго бита D
MOV C, B ;сохраним значение предыдущего переноса
XRA A
MOV B, A

MOV A, M
RAR
JNC nocddi
INR B
nocddi: ;отсутствие переноса при делении на 2
MOV E, A
MOV A, B
RRC
MOV B, A
MOV A, E

ANI 7F ;обнеление старшего бита

RAR
JNC nocddd
INR B
nocddd: ;отсутствие переноса при делении на 2
MOV E, A
MOV A, B
RRC
MOV B, A
MOV A, E
;nocdid: ;без переноса в старшем разряде A
ANI 7F ;обнеление старшего бита

ORA C

LXI H, 0B1A
MOV M, A

LXI H, 0B09 ;деление третьего бита D
MOV C, B ;сохраним значение предыдущего переноса
XRA A
MOV B, A

MOV A, M
RAR
JNC nocddi
INR B
nocddi: ;отсутствие переноса при делении на 2
MOV E, A
MOV A, B
RRC
MOV B, A
MOV A, E

ANI 7F ;обнеление старшего бита

RAR
JNC nocddd
INR B
nocddd: ;отсутствие переноса при делении на 2
MOV E, A
MOV A, B
RRC
MOV B, A
MOV A, E
;nocdid: ;без переноса в старшем разряде A
ANI 7F ;обнеление старшего бита

ORA C ;завершение деления

LXI H, 0B19
MOV M, A

LXI H, 0B08
MOV A, M
DCX H
MOV B, M
DCX H
MOV C, M

LXI H, 0B18
MOV M, A
DCX H
MOV M, B
DCX H
MOV M, C

LXI H, 0B05
MOV A, M
DCX H
DCX H
MOV B, M
DCX H
DCX H
MOV C, M

LXI H, 0B15
MOV M, A
DCX H
DCX H
MOV M, B
DCX H
DCX H
MOV M, C

HLT

LXI H,0B10 ; выполнение операций
MOV A, M
INX H
SUB M
MOV E, A
INX H
MOV A, M
INX H
SBB M
MOV D, A
INX H
MOV A, M
INX H
SBB M
MOV C, A

INX H
MOV A, M
RAL
RAL
ADD E
MOV E, A
INX H
MOV A, M
RAL
RAL
ADC D
MOV D, A
INX H
MOV A, M
RAL
RAL
ADC C
MOV C, A
INX H
MOV A, E

HLT

SBB M
STA 0B1D
INX H
MOV A, D
SBB M
STA 0B1E
INX H
MOV A, C
SBB M
STA 0B1F
HLT
