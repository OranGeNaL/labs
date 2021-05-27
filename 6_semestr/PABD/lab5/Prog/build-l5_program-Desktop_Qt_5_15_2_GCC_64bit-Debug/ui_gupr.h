/********************************************************************************
** Form generated from reading UI file 'gupr.ui'
**
** Created by: Qt User Interface Compiler version 5.15.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_GUPR_H
#define UI_GUPR_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QDialog>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QTableView>

QT_BEGIN_NAMESPACE

class Ui_Gupr
{
public:
    QTableView *guprTableView;
    QTableView *gupr_elTableView;
    QPushButton *addButton;
    QPushButton *delButton;

    void setupUi(QDialog *Gupr)
    {
        if (Gupr->objectName().isEmpty())
            Gupr->setObjectName(QString::fromUtf8("Gupr"));
        Gupr->resize(881, 514);
        guprTableView = new QTableView(Gupr);
        guprTableView->setObjectName(QString::fromUtf8("guprTableView"));
        guprTableView->setGeometry(QRect(200, 10, 671, 421));
        gupr_elTableView = new QTableView(Gupr);
        gupr_elTableView->setObjectName(QString::fromUtf8("gupr_elTableView"));
        gupr_elTableView->setGeometry(QRect(10, 10, 181, 421));
        addButton = new QPushButton(Gupr);
        addButton->setObjectName(QString::fromUtf8("addButton"));
        addButton->setGeometry(QRect(20, 450, 87, 27));
        delButton = new QPushButton(Gupr);
        delButton->setObjectName(QString::fromUtf8("delButton"));
        delButton->setGeometry(QRect(120, 450, 87, 27));

        retranslateUi(Gupr);

        QMetaObject::connectSlotsByName(Gupr);
    } // setupUi

    void retranslateUi(QDialog *Gupr)
    {
        Gupr->setWindowTitle(QCoreApplication::translate("Gupr", "\320\223\320\243\320\237\320\240", nullptr));
        addButton->setText(QCoreApplication::translate("Gupr", " \320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        delButton->setText(QCoreApplication::translate("Gupr", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Gupr: public Ui_Gupr {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_GUPR_H
