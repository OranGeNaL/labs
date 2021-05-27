/********************************************************************************
** Form generated from reading UI file 'kaf_rasp.ui'
**
** Created by: Qt User Interface Compiler version 5.15.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_KAF_RASP_H
#define UI_KAF_RASP_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QDialog>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QTableView>

QT_BEGIN_NAMESPACE

class Ui_Kaf_Rasp
{
public:
    QTableView *kaf_raspTableView;
    QPushButton *addButton;
    QPushButton *delButton;
    QComboBox *kafedraCombo;
    QComboBox *disciplineCombo;
    QLabel *label;
    QLabel *label_2;

    void setupUi(QDialog *Kaf_Rasp)
    {
        if (Kaf_Rasp->objectName().isEmpty())
            Kaf_Rasp->setObjectName(QString::fromUtf8("Kaf_Rasp"));
        Kaf_Rasp->resize(704, 529);
        kaf_raspTableView = new QTableView(Kaf_Rasp);
        kaf_raspTableView->setObjectName(QString::fromUtf8("kaf_raspTableView"));
        kaf_raspTableView->setGeometry(QRect(10, 90, 681, 371));
        addButton = new QPushButton(Kaf_Rasp);
        addButton->setObjectName(QString::fromUtf8("addButton"));
        addButton->setGeometry(QRect(10, 470, 87, 27));
        delButton = new QPushButton(Kaf_Rasp);
        delButton->setObjectName(QString::fromUtf8("delButton"));
        delButton->setGeometry(QRect(120, 470, 87, 27));
        kafedraCombo = new QComboBox(Kaf_Rasp);
        kafedraCombo->setObjectName(QString::fromUtf8("kafedraCombo"));
        kafedraCombo->setGeometry(QRect(10, 50, 291, 27));
        disciplineCombo = new QComboBox(Kaf_Rasp);
        disciplineCombo->setObjectName(QString::fromUtf8("disciplineCombo"));
        disciplineCombo->setGeometry(QRect(380, 50, 311, 27));
        label = new QLabel(Kaf_Rasp);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(10, 20, 101, 19));
        label_2 = new QLabel(Kaf_Rasp);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(380, 20, 101, 19));

        retranslateUi(Kaf_Rasp);

        QMetaObject::connectSlotsByName(Kaf_Rasp);
    } // setupUi

    void retranslateUi(QDialog *Kaf_Rasp)
    {
        Kaf_Rasp->setWindowTitle(QCoreApplication::translate("Kaf_Rasp", "\320\232\320\260\321\204\320\265\320\264\321\200\320\260 \321\200\320\260\321\201\320\277\321\200\320\265\320\264\320\265\320\273\320\265\320\275\320\270\321\217", nullptr));
        addButton->setText(QCoreApplication::translate("Kaf_Rasp", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        delButton->setText(QCoreApplication::translate("Kaf_Rasp", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
        label->setText(QCoreApplication::translate("Kaf_Rasp", "\320\232\320\260\321\204\320\265\320\264\321\200\320\260", nullptr));
        label_2->setText(QCoreApplication::translate("Kaf_Rasp", "\320\224\320\270\321\201\321\206\320\270\320\277\320\273\320\270\320\275\320\260", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Kaf_Rasp: public Ui_Kaf_Rasp {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_KAF_RASP_H
