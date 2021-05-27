#include "extensibleadd.h"
#include "ui_extensibleadd.h"

ExtensibleAdd::ExtensibleAdd(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::ExtensibleAdd)
{
    ui->setupUi(this);
}

ExtensibleAdd::~ExtensibleAdd()
{
    delete ui;
}

// 0 - text
// 1 - combo
// -1 - nothing
void ExtensibleAdd::SetInput(int ps1, int ps2, int ps3, int ps4)
{
    InputChange(0, ps1);
    InputChange(1, ps2);
    InputChange(2, ps3);
    InputChange(3, ps4);
}

void ExtensibleAdd::Set(QString s1, QString s2, QString s3, QString s4)
{
//    ui->lineEdit1->hide();
//    ui->lineEdit2->hide();
//    ui->lineEdit3->hide();
//    ui->lineEdit4->hide();

    ui->label1->setText(s1);
    ui->label2->setText(s2);
    ui->label3->setText(s3);
    ui->label4->setText(s4);

//    if(s1 != "")
//    {
//        ui->lineEdit1->show();
//    }
//    if(s2 != "")
//    {
//        ui->lineEdit2->show();
//    }
//    if(s3 != "")
//    {
//        ui->lineEdit3->show();
//    }
//    if(s4 != "")
//    {
//        ui->lineEdit4->show();
//    }

    ui->lineEdit1->setText("");
    ui->lineEdit2->setText("");
    ui->lineEdit3->setText("");
    ui->lineEdit4->setText("");
}

void ExtensibleAdd::on_addButton_clicked()
{
    arg1 = ui->lineEdit1->text();
    arg2 = ui->lineEdit2->text();
    arg3 = ui->lineEdit3->text();
    arg4 = ui->lineEdit4->text();

    emit sendPositive();
}

void ExtensibleAdd::InputChange(int ind, int type)
{
    QLineEdit * lines[] = {ui->lineEdit1, ui->lineEdit2, ui->lineEdit3, ui->lineEdit4};
    QComboBox * combos[] = {ui->comboBox, ui->comboBox2, ui->comboBox3, ui->comboBox4};

    switch (type) {
    case -1:
        lines[ind]->hide();
        combos[ind]->hide();
        break;
    case 0:
        lines[ind]->show();
        combos[ind]->hide();
        break;
    case 1:
        lines[ind]->hide();
        combos[ind]->show();
    }
}


void ExtensibleAdd::on_cancelButton_clicked()
{
    emit sendNegative();
}

