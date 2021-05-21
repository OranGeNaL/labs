#ifndef COURSE_H
#define COURSE_H

#include <QDialog>

namespace Ui {
class Course;
}

class Course : public QDialog
{
    Q_OBJECT

public:
    explicit Course(QWidget *parent = nullptr);
    ~Course();

private:
    Ui::Course *ui;
};

#endif // COURSE_H
