/********************************************************************************
** Form generated from reading UI file 'authorisation.ui'
**
** Created by: Qt User Interface Compiler version 5.15.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_AUTHORISATION_H
#define UI_AUTHORISATION_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpinBox>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Form
{
public:
    QPushButton *ButtonConnect;
    QPushButton *ButtonDisconnect;
    QLineEdit *editUser;
    QLineEdit *editHost;
    QLineEdit *editPassword;
    QSpinBox *spinBox;
    QLabel *label;
    QLabel *label_2;
    QLabel *label_3;
    QLabel *label_4;

    void setupUi(QWidget *Form)
    {
        if (Form->objectName().isEmpty())
            Form->setObjectName(QString::fromUtf8("Form"));
        Form->resize(400, 300);
        ButtonConnect = new QPushButton(Form);
        ButtonConnect->setObjectName(QString::fromUtf8("ButtonConnect"));
        ButtonConnect->setGeometry(QRect(50, 240, 121, 27));
        ButtonDisconnect = new QPushButton(Form);
        ButtonDisconnect->setObjectName(QString::fromUtf8("ButtonDisconnect"));
        ButtonDisconnect->setGeometry(QRect(216, 240, 111, 27));
        editUser = new QLineEdit(Form);
        editUser->setObjectName(QString::fromUtf8("editUser"));
        editUser->setGeometry(QRect(50, 150, 121, 27));
        editHost = new QLineEdit(Form);
        editHost->setObjectName(QString::fromUtf8("editHost"));
        editHost->setGeometry(QRect(50, 60, 121, 27));
        editPassword = new QLineEdit(Form);
        editPassword->setObjectName(QString::fromUtf8("editPassword"));
        editPassword->setGeometry(QRect(210, 150, 121, 27));
        spinBox = new QSpinBox(Form);
        spinBox->setObjectName(QString::fromUtf8("spinBox"));
        spinBox->setGeometry(QRect(210, 60, 121, 28));
        label = new QLabel(Form);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(50, 30, 66, 19));
        label_2 = new QLabel(Form);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(50, 120, 101, 19));
        label_3 = new QLabel(Form);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(210, 120, 66, 19));
        label_4 = new QLabel(Form);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setGeometry(QRect(210, 30, 66, 19));

        retranslateUi(Form);

        QMetaObject::connectSlotsByName(Form);
    } // setupUi

    void retranslateUi(QWidget *Form)
    {
        Form->setWindowTitle(QCoreApplication::translate("Form", "Form", nullptr));
        ButtonConnect->setText(QCoreApplication::translate("Form", "\320\237\320\276\320\264\320\272\320\273\321\216\321\207\320\270\321\202\321\214\321\201\321\217", nullptr));
        ButtonDisconnect->setText(QCoreApplication::translate("Form", "\320\236\321\202\320\272\320\273\321\216\321\207\320\270\321\202\321\214\321\201\321\217", nullptr));
        label->setText(QCoreApplication::translate("Form", "\320\245\320\276\321\201\321\202", nullptr));
        label_2->setText(QCoreApplication::translate("Form", "\320\237\320\276\320\273\321\214\320\267\320\276\320\262\320\260\321\202\320\265\320\273\321\214", nullptr));
        label_3->setText(QCoreApplication::translate("Form", "\320\237\320\260\321\200\320\276\320\273\321\214", nullptr));
        label_4->setText(QCoreApplication::translate("Form", "\320\237\320\276\321\200\321\202", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Form: public Ui_Form {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_AUTHORISATION_H
