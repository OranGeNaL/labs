#ifndef AUTHORIZATION_H
#define AUTHORIZATION_H

#include <QWidget>

namespace Ui {
class Authorization;
}

class Authorization : public QWidget
{
    Q_OBJECT

public:
    explicit Authorization(QWidget *parent = nullptr);
    ~Authorization();
    QString user;
    QString password;
    QString host;
    int port;

private:
    Ui::Authorization *ui;

signals:
    void sendConnect();
    void sendDisconnect();
private slots:
    void on_connectButton_clicked();
    void on_disconnectButton_clicked();
};

#endif // AUTHORIZATION_H
