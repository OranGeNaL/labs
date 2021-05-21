/********************************************************************************
** Form generated from reading UI file 'uch_plan.ui'
**
** Created by: Qt User Interface Compiler version 5.15.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_UCH_PLAN_H
#define UI_UCH_PLAN_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QDialog>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QTableView>

QT_BEGIN_NAMESPACE

class Ui_Uch_Plan
{
public:
    QTableView *uch_planTableView;
    QTableView *specialityTableView;
    QPushButton *addButton;
    QPushButton *delButton;

    void setupUi(QDialog *Uch_Plan)
    {
        if (Uch_Plan->objectName().isEmpty())
            Uch_Plan->setObjectName(QString::fromUtf8("Uch_Plan"));
        Uch_Plan->resize(802, 591);
        uch_planTableView = new QTableView(Uch_Plan);
        uch_planTableView->setObjectName(QString::fromUtf8("uch_planTableView"));
        uch_planTableView->setGeometry(QRect(20, 50, 441, 431));
        specialityTableView = new QTableView(Uch_Plan);
        specialityTableView->setObjectName(QString::fromUtf8("specialityTableView"));
        specialityTableView->setGeometry(QRect(490, 50, 291, 431));
        addButton = new QPushButton(Uch_Plan);
        addButton->setObjectName(QString::fromUtf8("addButton"));
        addButton->setGeometry(QRect(20, 490, 87, 27));
        delButton = new QPushButton(Uch_Plan);
        delButton->setObjectName(QString::fromUtf8("delButton"));
        delButton->setGeometry(QRect(120, 490, 87, 27));

        retranslateUi(Uch_Plan);

        QMetaObject::connectSlotsByName(Uch_Plan);
    } // setupUi

    void retranslateUi(QDialog *Uch_Plan)
    {
        Uch_Plan->setWindowTitle(QCoreApplication::translate("Uch_Plan", "\320\243\321\207\320\265\320\261\320\275\321\213\320\271 \320\277\320\273\320\260\320\275", nullptr));
        addButton->setText(QCoreApplication::translate("Uch_Plan", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        delButton->setText(QCoreApplication::translate("Uch_Plan", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Uch_Plan: public Ui_Uch_Plan {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_UCH_PLAN_H
