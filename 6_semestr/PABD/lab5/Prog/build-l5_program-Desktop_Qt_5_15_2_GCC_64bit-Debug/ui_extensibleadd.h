/********************************************************************************
** Form generated from reading UI file 'extensibleadd.ui'
**
** Created by: Qt User Interface Compiler version 5.15.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_EXTENSIBLEADD_H
#define UI_EXTENSIBLEADD_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QDialog>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPushButton>

QT_BEGIN_NAMESPACE

class Ui_ExtensibleAdd
{
public:
    QLineEdit *lineEdit1;
    QLabel *label1;
    QPushButton *cancelButton;
    QPushButton *addButton;
    QLabel *label2;
    QLineEdit *lineEdit2;
    QLineEdit *lineEdit4;
    QLabel *label4;
    QLabel *label3;
    QLineEdit *lineEdit3;
    QComboBox *comboBox;
    QComboBox *comboBox2;
    QComboBox *comboBox3;
    QComboBox *comboBox4;

    void setupUi(QDialog *ExtensibleAdd)
    {
        if (ExtensibleAdd->objectName().isEmpty())
            ExtensibleAdd->setObjectName(QString::fromUtf8("ExtensibleAdd"));
        ExtensibleAdd->resize(513, 262);
        lineEdit1 = new QLineEdit(ExtensibleAdd);
        lineEdit1->setObjectName(QString::fromUtf8("lineEdit1"));
        lineEdit1->setGeometry(QRect(10, 70, 191, 27));
        label1 = new QLabel(ExtensibleAdd);
        label1->setObjectName(QString::fromUtf8("label1"));
        label1->setGeometry(QRect(10, 40, 241, 19));
        cancelButton = new QPushButton(ExtensibleAdd);
        cancelButton->setObjectName(QString::fromUtf8("cancelButton"));
        cancelButton->setGeometry(QRect(150, 200, 87, 27));
        addButton = new QPushButton(ExtensibleAdd);
        addButton->setObjectName(QString::fromUtf8("addButton"));
        addButton->setGeometry(QRect(10, 200, 121, 27));
        label2 = new QLabel(ExtensibleAdd);
        label2->setObjectName(QString::fromUtf8("label2"));
        label2->setGeometry(QRect(10, 110, 241, 19));
        lineEdit2 = new QLineEdit(ExtensibleAdd);
        lineEdit2->setObjectName(QString::fromUtf8("lineEdit2"));
        lineEdit2->setGeometry(QRect(10, 140, 191, 27));
        lineEdit4 = new QLineEdit(ExtensibleAdd);
        lineEdit4->setObjectName(QString::fromUtf8("lineEdit4"));
        lineEdit4->setGeometry(QRect(250, 140, 191, 27));
        label4 = new QLabel(ExtensibleAdd);
        label4->setObjectName(QString::fromUtf8("label4"));
        label4->setGeometry(QRect(250, 110, 241, 19));
        label3 = new QLabel(ExtensibleAdd);
        label3->setObjectName(QString::fromUtf8("label3"));
        label3->setGeometry(QRect(250, 40, 241, 19));
        lineEdit3 = new QLineEdit(ExtensibleAdd);
        lineEdit3->setObjectName(QString::fromUtf8("lineEdit3"));
        lineEdit3->setGeometry(QRect(250, 70, 191, 27));
        comboBox = new QComboBox(ExtensibleAdd);
        comboBox->setObjectName(QString::fromUtf8("comboBox"));
        comboBox->setGeometry(QRect(10, 70, 191, 27));
        comboBox2 = new QComboBox(ExtensibleAdd);
        comboBox2->setObjectName(QString::fromUtf8("comboBox2"));
        comboBox2->setGeometry(QRect(10, 140, 191, 27));
        comboBox3 = new QComboBox(ExtensibleAdd);
        comboBox3->setObjectName(QString::fromUtf8("comboBox3"));
        comboBox3->setGeometry(QRect(250, 70, 191, 27));
        comboBox4 = new QComboBox(ExtensibleAdd);
        comboBox4->setObjectName(QString::fromUtf8("comboBox4"));
        comboBox4->setGeometry(QRect(250, 140, 191, 27));

        retranslateUi(ExtensibleAdd);

        QMetaObject::connectSlotsByName(ExtensibleAdd);
    } // setupUi

    void retranslateUi(QDialog *ExtensibleAdd)
    {
        ExtensibleAdd->setWindowTitle(QCoreApplication::translate("ExtensibleAdd", "Dialog", nullptr));
        label1->setText(QCoreApplication::translate("ExtensibleAdd", "TextLabel", nullptr));
        cancelButton->setText(QCoreApplication::translate("ExtensibleAdd", "\320\236\321\202\320\274\320\265\320\275\320\260", nullptr));
        addButton->setText(QCoreApplication::translate("ExtensibleAdd", "\320\237\320\276\320\264\321\202\320\262\320\265\321\200\320\264\320\270\321\202\321\214", nullptr));
        label2->setText(QCoreApplication::translate("ExtensibleAdd", "TextLabel", nullptr));
        label4->setText(QCoreApplication::translate("ExtensibleAdd", "TextLabel", nullptr));
        label3->setText(QCoreApplication::translate("ExtensibleAdd", "TextLabel", nullptr));
    } // retranslateUi

};

namespace Ui {
    class ExtensibleAdd: public Ui_ExtensibleAdd {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_EXTENSIBLEADD_H
