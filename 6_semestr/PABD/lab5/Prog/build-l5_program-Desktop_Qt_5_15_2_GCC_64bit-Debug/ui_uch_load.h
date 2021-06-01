/********************************************************************************
** Form generated from reading UI file 'uch_load.ui'
**
** Created by: Qt User Interface Compiler version 5.15.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_UCH_LOAD_H
#define UI_UCH_LOAD_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QDialog>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QTableView>

QT_BEGIN_NAMESPACE

class Ui_Uch_Load
{
public:
    QTableView *uch_loadTableView;
    QPushButton *addButton;
    QPushButton *delButton;
    QComboBox *discCombo;
    QLabel *label;
    QLabel *label_2;
    QLabel *label_3;
    QLabel *planLabel;
    QLabel *specLabel;

    void setupUi(QDialog *Uch_Load)
    {
        if (Uch_Load->objectName().isEmpty())
            Uch_Load->setObjectName(QString::fromUtf8("Uch_Load"));
        Uch_Load->resize(821, 548);
        uch_loadTableView = new QTableView(Uch_Load);
        uch_loadTableView->setObjectName(QString::fromUtf8("uch_loadTableView"));
        uch_loadTableView->setGeometry(QRect(10, 90, 801, 381));
        addButton = new QPushButton(Uch_Load);
        addButton->setObjectName(QString::fromUtf8("addButton"));
        addButton->setGeometry(QRect(10, 480, 87, 27));
        delButton = new QPushButton(Uch_Load);
        delButton->setObjectName(QString::fromUtf8("delButton"));
        delButton->setGeometry(QRect(110, 480, 87, 27));
        discCombo = new QComboBox(Uch_Load);
        discCombo->setObjectName(QString::fromUtf8("discCombo"));
        discCombo->setGeometry(QRect(10, 50, 241, 27));
        label = new QLabel(Uch_Load);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(10, 20, 211, 19));
        label_2 = new QLabel(Uch_Load);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(390, 20, 66, 19));
        label_3 = new QLabel(Uch_Load);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(390, 50, 111, 19));
        planLabel = new QLabel(Uch_Load);
        planLabel->setObjectName(QString::fromUtf8("planLabel"));
        planLabel->setGeometry(QRect(510, 20, 301, 19));
        specLabel = new QLabel(Uch_Load);
        specLabel->setObjectName(QString::fromUtf8("specLabel"));
        specLabel->setGeometry(QRect(510, 50, 301, 19));

        retranslateUi(Uch_Load);

        QMetaObject::connectSlotsByName(Uch_Load);
    } // setupUi

    void retranslateUi(QDialog *Uch_Load)
    {
        Uch_Load->setWindowTitle(QCoreApplication::translate("Uch_Load", "\320\243\321\207\320\265\320\261\320\275\320\260\321\217 \320\275\320\260\320\263\321\200\321\203\320\267\320\272\320\260", nullptr));
        addButton->setText(QCoreApplication::translate("Uch_Load", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        delButton->setText(QCoreApplication::translate("Uch_Load", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
        label->setText(QCoreApplication::translate("Uch_Load", "\320\224\320\270\321\201\321\206\320\270\320\277\320\273\320\270\320\275\320\260", nullptr));
        label_2->setText(QCoreApplication::translate("Uch_Load", "\320\237\320\273\320\260\320\275:", nullptr));
        label_3->setText(QCoreApplication::translate("Uch_Load", "\320\241\320\277\320\265\321\206\320\270\320\260\320\273\321\214\320\275\320\276\321\201\321\202\321\214: ", nullptr));
        planLabel->setText(QCoreApplication::translate("Uch_Load", "TextLabel", nullptr));
        specLabel->setText(QCoreApplication::translate("Uch_Load", "TextLabel", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Uch_Load: public Ui_Uch_Load {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_UCH_LOAD_H
