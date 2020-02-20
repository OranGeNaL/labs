#include <string.h>
#include <string>

using namespace std;




string FileReading(char *name, string text)
{
    FILE *origin;
    origin = fopen(name, "r");
    if (origin != NULL)
    {
        char buf[1000];
        while ((fgets(buf, 1000, origin)) != NULL)
        {
            text.insert(text.length(), buf);
        }
        fclose(origin);
    }
    else
    {
        printf("Такого файла не существует\n");
    }

    return text;
}

void FileCreating(char *qway, string fintext)
{
    FILE *qfile;
    qfile = fopen(qway, "w");
    fputs(fintext.c_str(), qfile);
    fclose(qfile);
}