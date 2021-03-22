#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/errno.h> 
#include <sys/wait.h> 
#include <time.h>
#include <errno.h>


#define TEST "./ex2"
#define TEST1 "./ex3"

void error();

int main(int argc, char *argv[])
{

time_t It;
It = time(NULL);
errno = 0;
printf("PID_parent_progam = %d , PPID_zad1 = %d\n", getpid(), getppid());
printf("parent_progam %s...\n", argv[0]);
printf ("Time_begin_parent_progam = %s", ctime(&It));
//printf("\nВыполняется %s", argv[0]);

int rc, cnt, er;

if (rc = fork() == 0) 
    execv("ex", argv);
else
    wait(NULL);



if (rc = fork() == 0) 
    execl("ex1", "ex1", "HELLO,", "WORLD", NULL);
else
    wait(NULL);


if (rc = fork() == 0) 
    execvp(TEST, argv);
else
    wait(NULL);


if (rc = fork() == 0)  
    execlp(TEST1, TEST1, "hello", NULL);
else
    wait(NULL);



It = time(NULL);
printf("\nParent program ending\n");
printf ("Time_end_parent_program = %s", ctime(&It));
printf("PID=%d PPID=%d Time_end_parent_program - %s \n",getpid(),getppid(),ctime(&It));

if(errno)
{
	error();
}

return 0;
}

void error()
{
	switch(errno)
	{
	case EDOM:
	printf("errno = %d ошибка области допустимых значений",errno);
break;
	case EILSEQ:
	printf("errno = %d ошибочная последовательность байтов",errno);
break;
	case ERANGE:
	printf("errno = %d результат слишком велик",errno);
break;
	case EACCES:
	printf("errno = %d доступ к файлу запрещен",errno);
break;
	case ENOEXEC:
	printf("errno = %d заголовок файла не распознается",errno);
break;
	case ENOENT:
	printf("errno = %d файл не найден",errno);
	default:
break;
	
	}
}


