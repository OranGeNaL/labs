#include "course.h"
#include "ui_course.h"

Course::Course(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Course)
{
    ui->setupUi(this);



}

Course::~Course()
{
    delete ui;
}
