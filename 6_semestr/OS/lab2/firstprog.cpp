#include<stdio.h>
#include<cstdlib>
#include<unistd.h>
#include<sys/wait.h>

int *count = new int;

int main(int argc, char **argv){
    int order[4];

    for(int i = 1; i <= 4; i++)
    {
        order[i - 1] = atoi(argv[i]);
    }

    // for(int i = 0; i < 4; i++)
    // {
    //     printf("%d. Номер %d\n", i + 1, order[i]);
    // }

    int pid;
    *count = 0;
    int status;

    do
    {
        pid = fork();
        *count++;
    } while (pid != 0 && *count < 4);
    

    if(pid == 0)
    {
        // printf("hellop");
        printf("Ясукадочерний %d, батя %d\n", getpid(), getppid());
    }
    else
    {
        wait(&status);
        printf("Радитель %d\n", getpid());
    }
}