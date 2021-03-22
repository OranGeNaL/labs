#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <stdlib.h>
#include <sys/errno.h> 
#include <sys/wait.h> 
#include <time.h>
#include <string.h>

#define TEST "./ex2"
#define TEST1 "./ex3"

int main(int argc, char *argv[])
{

time_t It;
It = time(NULL);
printf("PID_zad1 = %d , PPID_zad1 = %d\n", getpid(), getppid());
printf("Программа %s будет выполнена...\n", argv[0]);
printf ("Time_begin_zad1 = %s", ctime(&It));

int pid1, pid2, pid3, pid4, rc;
int main_proc = -1;

pid1 = fork(); //forking1
if (pid1 < 0)
{
printf("Error forking...\n");
exit(1);
}


if (pid1 == 0)
{
printf ("\nProgram 1\n");
rc = execv("ex", argv);
exit(rc);
}

if (pid1 > 0)
main_proc = 0;


if (main_proc == 0)
{
pid2 = fork(); //forking2
if (pid2 < 0)
{
printf("Error forking...\n");
exit(2);
}

if (pid2 == 0)
{
printf ("\nProgram 2\n");
rc = execl("ex1", "ex1", "HELLO,", "WORLD", NULL);
exit(rc);
}
}


if (main_proc == 0)
{
pid3 = fork(); //forking3

if (pid3 < 0)
{
printf("Error forking...\n");
exit(3);
}

if (pid3 == 0)
{
printf ("\nProgram 3\n");
rc = execvp(TEST, argv);
exit(rc);
}
}


if (main_proc == 0)
{
pid4 = fork(); //forking4

if (pid4 < 0)
{
printf("Error forking...\n");
exit(4);
}

if (pid4 == 0)
{
printf ("\nProgram 4\n");
rc = execlp(TEST1, TEST1, "hello", NULL);
exit(rc);
}
}


int rc_, pid_;
if (main_proc == 0)
for (int i = 0; i<4; i++)
{
  pid_ = wait(rc_);
  
  if (pid_ == pid1)
{
    errno = rc_;
    printf ("\nПрограмма 1 завершилась с кодом %d (%s) \n", errno, strerror(errno));
}

  if (pid_ == pid2)
{
    errno = rc_;
    printf ("\nПрограмма 2 завершилась с кодом %d (%s) \n", errno, strerror(errno));
}
  
  if (pid_ == pid3)
{
    errno = rc_;
    printf ("\nПрограмма 3 завершилась с кодом %d (%s) \n", errno, strerror(errno));
}

  if (pid_ == pid4)
{
    errno = rc_;
    printf ("\nПрограмма 4 завершилась с кодом %d (%s) \n", errno, strerror(errno));
}
}


It = time(NULL);
printf("\nParent program ending\n");
printf ("Time_end_zad1 = %s", ctime(&It));

return 0;
}
