/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.15.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTableView>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralwidget;
    QTableView *tableView;
    QLineEdit *editSearch;
    QPushButton *buttonClear;
    QPushButton *addButton;
    QPushButton *deleteButton;
    QPushButton *pushButton_3;
    QPushButton *pushButton_4;
    QComboBox *disciplineCombo;
    QLabel *disciplineLabel;
    QLabel *disciplineLabel_2;
    QComboBox *yearCombo;
    QComboBox *groupCombo;
    QLabel *disciplineLabel_3;
    QComboBox *specialityCombo;
    QLabel *disciplineLabel_4;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QString::fromUtf8("MainWindow"));
        MainWindow->resize(833, 629);
        centralwidget = new QWidget(MainWindow);
        centralwidget->setObjectName(QString::fromUtf8("centralwidget"));
        tableView = new QTableView(centralwidget);
        tableView->setObjectName(QString::fromUtf8("tableView"));
        tableView->setGeometry(QRect(20, 70, 671, 471));
        editSearch = new QLineEdit(centralwidget);
        editSearch->setObjectName(QString::fromUtf8("editSearch"));
        editSearch->setGeometry(QRect(20, 550, 561, 27));
        buttonClear = new QPushButton(centralwidget);
        buttonClear->setObjectName(QString::fromUtf8("buttonClear"));
        buttonClear->setGeometry(QRect(600, 550, 87, 27));
        addButton = new QPushButton(centralwidget);
        addButton->setObjectName(QString::fromUtf8("addButton"));
        addButton->setGeometry(QRect(720, 60, 87, 27));
        deleteButton = new QPushButton(centralwidget);
        deleteButton->setObjectName(QString::fromUtf8("deleteButton"));
        deleteButton->setGeometry(QRect(720, 100, 87, 27));
        pushButton_3 = new QPushButton(centralwidget);
        pushButton_3->setObjectName(QString::fromUtf8("pushButton_3"));
        pushButton_3->setGeometry(QRect(720, 140, 87, 27));
        pushButton_4 = new QPushButton(centralwidget);
        pushButton_4->setObjectName(QString::fromUtf8("pushButton_4"));
        pushButton_4->setGeometry(QRect(720, 180, 87, 27));
        disciplineCombo = new QComboBox(centralwidget);
        disciplineCombo->setObjectName(QString::fromUtf8("disciplineCombo"));
        disciplineCombo->setGeometry(QRect(20, 40, 111, 27));
        disciplineLabel = new QLabel(centralwidget);
        disciplineLabel->setObjectName(QString::fromUtf8("disciplineLabel"));
        disciplineLabel->setGeometry(QRect(20, 10, 91, 19));
        disciplineLabel_2 = new QLabel(centralwidget);
        disciplineLabel_2->setObjectName(QString::fromUtf8("disciplineLabel_2"));
        disciplineLabel_2->setGeometry(QRect(140, 10, 111, 19));
        yearCombo = new QComboBox(centralwidget);
        yearCombo->setObjectName(QString::fromUtf8("yearCombo"));
        yearCombo->setGeometry(QRect(140, 40, 111, 27));
        groupCombo = new QComboBox(centralwidget);
        groupCombo->setObjectName(QString::fromUtf8("groupCombo"));
        groupCombo->setGeometry(QRect(260, 40, 111, 27));
        disciplineLabel_3 = new QLabel(centralwidget);
        disciplineLabel_3->setObjectName(QString::fromUtf8("disciplineLabel_3"));
        disciplineLabel_3->setGeometry(QRect(260, 10, 91, 19));
        specialityCombo = new QComboBox(centralwidget);
        specialityCombo->setObjectName(QString::fromUtf8("specialityCombo"));
        specialityCombo->setGeometry(QRect(380, 40, 111, 27));
        disciplineLabel_4 = new QLabel(centralwidget);
        disciplineLabel_4->setObjectName(QString::fromUtf8("disciplineLabel_4"));
        disciplineLabel_4->setGeometry(QRect(380, 10, 111, 19));
        MainWindow->setCentralWidget(centralwidget);
        menubar = new QMenuBar(MainWindow);
        menubar->setObjectName(QString::fromUtf8("menubar"));
        menubar->setGeometry(QRect(0, 0, 833, 24));
        MainWindow->setMenuBar(menubar);
        statusbar = new QStatusBar(MainWindow);
        statusbar->setObjectName(QString::fromUtf8("statusbar"));
        MainWindow->setStatusBar(statusbar);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QCoreApplication::translate("MainWindow", "MainWindow", nullptr));
        buttonClear->setText(QCoreApplication::translate("MainWindow", "\320\236\321\207\320\270\321\201\321\202\320\270\321\202\321\214", nullptr));
        addButton->setText(QCoreApplication::translate("MainWindow", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        deleteButton->setText(QCoreApplication::translate("MainWindow", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
        pushButton_3->setText(QCoreApplication::translate("MainWindow", "PushButton", nullptr));
        pushButton_4->setText(QCoreApplication::translate("MainWindow", "PushButton", nullptr));
        disciplineLabel->setText(QCoreApplication::translate("MainWindow", "\320\224\320\270\321\201\321\206\320\270\320\277\320\273\320\270\320\275\320\260", nullptr));
        disciplineLabel_2->setText(QCoreApplication::translate("MainWindow", "\320\223\320\276\320\264 \320\267\320\260\321\207\320\270\321\201\320\273\320\265\320\275\320\270\321\217", nullptr));
        disciplineLabel_3->setText(QCoreApplication::translate("MainWindow", "\320\223\321\200\321\203\320\277\320\277\320\260", nullptr));
        disciplineLabel_4->setText(QCoreApplication::translate("MainWindow", "\320\241\320\277\320\265\321\206\320\270\320\260\320\273\321\214\320\275\320\276\321\201\321\202\321\214", nullptr));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
