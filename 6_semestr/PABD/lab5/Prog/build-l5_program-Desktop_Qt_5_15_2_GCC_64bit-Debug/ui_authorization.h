/********************************************************************************
** Form generated from reading UI file 'authorization.ui'
**
** Created by: Qt User Interface Compiler version 5.15.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_AUTHORIZATION_H
#define UI_AUTHORIZATION_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpinBox>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Authorization
{
public:
    QLabel *label;
    QLineEdit *editHost;
    QLineEdit *editUser;
    QLabel *label_2;
    QLineEdit *editPassword;
    QLabel *label_3;
    QLabel *label_4;
    QSpinBox *editPort;
    QPushButton *connectButton;
    QPushButton *disconnectButton;

    void setupUi(QWidget *Authorization)
    {
        if (Authorization->objectName().isEmpty())
            Authorization->setObjectName(QString::fromUtf8("Authorization"));
        Authorization->resize(337, 243);
        label = new QLabel(Authorization);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(30, 40, 91, 19));
        editHost = new QLineEdit(Authorization);
        editHost->setObjectName(QString::fromUtf8("editHost"));
        editHost->setGeometry(QRect(30, 70, 113, 27));
        editUser = new QLineEdit(Authorization);
        editUser->setObjectName(QString::fromUtf8("editUser"));
        editUser->setGeometry(QRect(30, 150, 113, 27));
        label_2 = new QLabel(Authorization);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(30, 120, 111, 19));
        editPassword = new QLineEdit(Authorization);
        editPassword->setObjectName(QString::fromUtf8("editPassword"));
        editPassword->setGeometry(QRect(190, 150, 113, 27));
        editPassword->setEchoMode(QLineEdit::Password);
        label_3 = new QLabel(Authorization);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(190, 120, 91, 19));
        label_4 = new QLabel(Authorization);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setGeometry(QRect(190, 40, 91, 19));
        editPort = new QSpinBox(Authorization);
        editPort->setObjectName(QString::fromUtf8("editPort"));
        editPort->setGeometry(QRect(190, 70, 111, 28));
        editPort->setMaximum(10000);
        editPort->setValue(5432);
        connectButton = new QPushButton(Authorization);
        connectButton->setObjectName(QString::fromUtf8("connectButton"));
        connectButton->setGeometry(QRect(30, 200, 111, 27));
        disconnectButton = new QPushButton(Authorization);
        disconnectButton->setObjectName(QString::fromUtf8("disconnectButton"));
        disconnectButton->setGeometry(QRect(190, 200, 111, 27));

        retranslateUi(Authorization);

        QMetaObject::connectSlotsByName(Authorization);
    } // setupUi

    void retranslateUi(QWidget *Authorization)
    {
        Authorization->setWindowTitle(QCoreApplication::translate("Authorization", "\320\220\320\262\321\202\320\276\321\200\320\270\320\267\320\260\321\206\320\270\321\217", nullptr));
        label->setText(QCoreApplication::translate("Authorization", "\320\230\320\274\321\217 \321\205\320\276\321\201\321\202\320\260", nullptr));
        editHost->setText(QCoreApplication::translate("Authorization", "192.168.122.69", nullptr));
        editUser->setText(QCoreApplication::translate("Authorization", "orangenal", nullptr));
        label_2->setText(QCoreApplication::translate("Authorization", "\320\237\320\276\320\273\321\214\320\267\320\276\320\262\320\260\321\202\320\265\320\273\321\214", nullptr));
        editPassword->setText(QCoreApplication::translate("Authorization", "1488", nullptr));
        label_3->setText(QCoreApplication::translate("Authorization", "\320\237\320\260\321\200\320\276\320\273\321\214", nullptr));
        label_4->setText(QCoreApplication::translate("Authorization", "\320\237\320\276\321\200\321\202", nullptr));
        connectButton->setText(QCoreApplication::translate("Authorization", "\320\241\320\276\320\265\320\264\320\270\320\275\320\270\321\202\321\214\321\201\321\217", nullptr));
        disconnectButton->setText(QCoreApplication::translate("Authorization", "\320\236\321\202\320\272\320\273\321\216\321\207\320\270\321\202\321\214\321\201\321\217", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Authorization: public Ui_Authorization {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_AUTHORIZATION_H
