#include "authorization.h"
#include "ui_authorization.h"

Authorization::Authorization(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Authorization)
{
    ui->setupUi(this);
}

Authorization::~Authorization()
{
    delete ui;
}

void Authorization::on_connectButton_clicked()
{
    host = ui->editHost->text();
    port = ui->editPort->value();
    user = ui->editUser->text();
    password = ui->editPassword->text();
    emit sendConnect();
}


void Authorization::on_disconnectButton_clicked()
{
    ui->editUser->setText("");
    ui->editPassword->setText("");
    emit sendDisconnect();
}

