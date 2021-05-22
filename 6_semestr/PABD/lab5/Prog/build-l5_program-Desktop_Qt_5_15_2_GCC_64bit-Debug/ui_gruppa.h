/********************************************************************************
** Form generated from reading UI file 'gruppa.ui'
**
** Created by: Qt User Interface Compiler version 5.15.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_GRUPPA_H
#define UI_GRUPPA_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QDialog>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QTableView>

QT_BEGIN_NAMESPACE

class Ui_Gruppa
{
public:
    QTableView *groupTableView;
    QComboBox *specialityCombo;
    QComboBox *uch_planCombo;
    QPushButton *addButton;
    QPushButton *delButton;

    void setupUi(QDialog *Gruppa)
    {
        if (Gruppa->objectName().isEmpty())
            Gruppa->setObjectName(QString::fromUtf8("Gruppa"));
        Gruppa->resize(723, 531);
        groupTableView = new QTableView(Gruppa);
        groupTableView->setObjectName(QString::fromUtf8("groupTableView"));
        groupTableView->setGeometry(QRect(10, 60, 701, 391));
        specialityCombo = new QComboBox(Gruppa);
        specialityCombo->setObjectName(QString::fromUtf8("specialityCombo"));
        specialityCombo->setGeometry(QRect(10, 20, 351, 27));
        uch_planCombo = new QComboBox(Gruppa);
        uch_planCombo->setObjectName(QString::fromUtf8("uch_planCombo"));
        uch_planCombo->setGeometry(QRect(380, 20, 331, 27));
        addButton = new QPushButton(Gruppa);
        addButton->setObjectName(QString::fromUtf8("addButton"));
        addButton->setGeometry(QRect(10, 460, 87, 27));
        delButton = new QPushButton(Gruppa);
        delButton->setObjectName(QString::fromUtf8("delButton"));
        delButton->setGeometry(QRect(110, 460, 87, 27));

        retranslateUi(Gruppa);

        QMetaObject::connectSlotsByName(Gruppa);
    } // setupUi

    void retranslateUi(QDialog *Gruppa)
    {
        Gruppa->setWindowTitle(QCoreApplication::translate("Gruppa", "\320\223\321\200\321\203\320\277\320\277\320\260", nullptr));
        addButton->setText(QCoreApplication::translate("Gruppa", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        delButton->setText(QCoreApplication::translate("Gruppa", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Gruppa: public Ui_Gruppa {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_GRUPPA_H
