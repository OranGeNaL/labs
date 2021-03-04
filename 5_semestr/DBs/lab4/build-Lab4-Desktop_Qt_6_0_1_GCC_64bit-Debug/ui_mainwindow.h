/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 6.0.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTabWidget>
#include <QtWidgets/QTableView>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralwidget;
    QTabWidget *tabWidget;
    QWidget *KafedraPage;
    QTableView *KafedraView;
    QPushButton *pushButton;
    QPushButton *pushButton_2;
    QPushButton *pushButton_3;
    QPushButton *pushButton_4;
    QWidget *ValuePage;
    QTableView *ValueView;
    QPushButton *pushButton_5;
    QPushButton *pushButton_6;
    QPushButton *pushButton_7;
    QPushButton *pushButton_8;
    QWidget *KategoriaPage;
    QPushButton *pushButton_12;
    QPushButton *pushButton_9;
    QTableView *KategoriaView;
    QPushButton *pushButton_10;
    QPushButton *pushButton_11;
    QWidget *YearPage;
    QTableView *YearView;
    QPushButton *pushButton_13;
    QPushButton *pushButton_14;
    QPushButton *pushButton_15;
    QPushButton *pushButton_16;
    QWidget *ChislennostPage;
    QTableView *ChislennostView;
    QPushButton *pushButton_17;
    QPushButton *pushButton_18;
    QPushButton *pushButton_19;
    QPushButton *pushButton_20;
    QComboBox *cbChooseKaf;
    QComboBox *cbChooseVal;
    QComboBox *cbChooseKat;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QString::fromUtf8("MainWindow"));
        MainWindow->resize(1406, 578);
        centralwidget = new QWidget(MainWindow);
        centralwidget->setObjectName(QString::fromUtf8("centralwidget"));
        tabWidget = new QTabWidget(centralwidget);
        tabWidget->setObjectName(QString::fromUtf8("tabWidget"));
        tabWidget->setGeometry(QRect(6, 9, 1361, 541));
        KafedraPage = new QWidget();
        KafedraPage->setObjectName(QString::fromUtf8("KafedraPage"));
        KafedraView = new QTableView(KafedraPage);
        KafedraView->setObjectName(QString::fromUtf8("KafedraView"));
        KafedraView->setGeometry(QRect(10, 10, 781, 441));
        pushButton = new QPushButton(KafedraPage);
        pushButton->setObjectName(QString::fromUtf8("pushButton"));
        pushButton->setGeometry(QRect(10, 470, 80, 25));
        pushButton_2 = new QPushButton(KafedraPage);
        pushButton_2->setObjectName(QString::fromUtf8("pushButton_2"));
        pushButton_2->setGeometry(QRect(110, 470, 80, 25));
        pushButton_3 = new QPushButton(KafedraPage);
        pushButton_3->setObjectName(QString::fromUtf8("pushButton_3"));
        pushButton_3->setGeometry(QRect(210, 470, 101, 25));
        pushButton_4 = new QPushButton(KafedraPage);
        pushButton_4->setObjectName(QString::fromUtf8("pushButton_4"));
        pushButton_4->setGeometry(QRect(330, 470, 80, 25));
        tabWidget->addTab(KafedraPage, QString());
        ValuePage = new QWidget();
        ValuePage->setObjectName(QString::fromUtf8("ValuePage"));
        ValueView = new QTableView(ValuePage);
        ValueView->setObjectName(QString::fromUtf8("ValueView"));
        ValueView->setGeometry(QRect(10, 10, 781, 441));
        pushButton_5 = new QPushButton(ValuePage);
        pushButton_5->setObjectName(QString::fromUtf8("pushButton_5"));
        pushButton_5->setGeometry(QRect(330, 470, 80, 25));
        pushButton_6 = new QPushButton(ValuePage);
        pushButton_6->setObjectName(QString::fromUtf8("pushButton_6"));
        pushButton_6->setGeometry(QRect(10, 470, 80, 25));
        pushButton_7 = new QPushButton(ValuePage);
        pushButton_7->setObjectName(QString::fromUtf8("pushButton_7"));
        pushButton_7->setGeometry(QRect(210, 470, 101, 25));
        pushButton_8 = new QPushButton(ValuePage);
        pushButton_8->setObjectName(QString::fromUtf8("pushButton_8"));
        pushButton_8->setGeometry(QRect(110, 470, 80, 25));
        tabWidget->addTab(ValuePage, QString());
        KategoriaPage = new QWidget();
        KategoriaPage->setObjectName(QString::fromUtf8("KategoriaPage"));
        pushButton_12 = new QPushButton(KategoriaPage);
        pushButton_12->setObjectName(QString::fromUtf8("pushButton_12"));
        pushButton_12->setGeometry(QRect(110, 470, 80, 25));
        pushButton_9 = new QPushButton(KategoriaPage);
        pushButton_9->setObjectName(QString::fromUtf8("pushButton_9"));
        pushButton_9->setGeometry(QRect(330, 470, 80, 25));
        KategoriaView = new QTableView(KategoriaPage);
        KategoriaView->setObjectName(QString::fromUtf8("KategoriaView"));
        KategoriaView->setGeometry(QRect(10, 10, 781, 441));
        pushButton_10 = new QPushButton(KategoriaPage);
        pushButton_10->setObjectName(QString::fromUtf8("pushButton_10"));
        pushButton_10->setGeometry(QRect(10, 470, 80, 25));
        pushButton_11 = new QPushButton(KategoriaPage);
        pushButton_11->setObjectName(QString::fromUtf8("pushButton_11"));
        pushButton_11->setGeometry(QRect(210, 470, 101, 25));
        tabWidget->addTab(KategoriaPage, QString());
        YearPage = new QWidget();
        YearPage->setObjectName(QString::fromUtf8("YearPage"));
        YearView = new QTableView(YearPage);
        YearView->setObjectName(QString::fromUtf8("YearView"));
        YearView->setGeometry(QRect(10, 10, 781, 441));
        pushButton_13 = new QPushButton(YearPage);
        pushButton_13->setObjectName(QString::fromUtf8("pushButton_13"));
        pushButton_13->setGeometry(QRect(330, 470, 80, 25));
        pushButton_14 = new QPushButton(YearPage);
        pushButton_14->setObjectName(QString::fromUtf8("pushButton_14"));
        pushButton_14->setGeometry(QRect(10, 470, 80, 25));
        pushButton_15 = new QPushButton(YearPage);
        pushButton_15->setObjectName(QString::fromUtf8("pushButton_15"));
        pushButton_15->setGeometry(QRect(210, 470, 101, 25));
        pushButton_16 = new QPushButton(YearPage);
        pushButton_16->setObjectName(QString::fromUtf8("pushButton_16"));
        pushButton_16->setGeometry(QRect(110, 470, 80, 25));
        tabWidget->addTab(YearPage, QString());
        ChislennostPage = new QWidget();
        ChislennostPage->setObjectName(QString::fromUtf8("ChislennostPage"));
        ChislennostView = new QTableView(ChislennostPage);
        ChislennostView->setObjectName(QString::fromUtf8("ChislennostView"));
        ChislennostView->setGeometry(QRect(10, 70, 401, 391));
        pushButton_17 = new QPushButton(ChislennostPage);
        pushButton_17->setObjectName(QString::fromUtf8("pushButton_17"));
        pushButton_17->setGeometry(QRect(330, 470, 80, 25));
        pushButton_18 = new QPushButton(ChislennostPage);
        pushButton_18->setObjectName(QString::fromUtf8("pushButton_18"));
        pushButton_18->setGeometry(QRect(10, 470, 80, 25));
        pushButton_19 = new QPushButton(ChislennostPage);
        pushButton_19->setObjectName(QString::fromUtf8("pushButton_19"));
        pushButton_19->setGeometry(QRect(210, 470, 101, 25));
        pushButton_20 = new QPushButton(ChislennostPage);
        pushButton_20->setObjectName(QString::fromUtf8("pushButton_20"));
        pushButton_20->setGeometry(QRect(110, 470, 80, 25));
        cbChooseKaf = new QComboBox(ChislennostPage);
        cbChooseKaf->setObjectName(QString::fromUtf8("cbChooseKaf"));
        cbChooseKaf->setGeometry(QRect(10, 20, 421, 25));
        cbChooseVal = new QComboBox(ChislennostPage);
        cbChooseVal->setObjectName(QString::fromUtf8("cbChooseVal"));
        cbChooseVal->setGeometry(QRect(450, 20, 221, 25));
        cbChooseKat = new QComboBox(ChislennostPage);
        cbChooseKat->setObjectName(QString::fromUtf8("cbChooseKat"));
        cbChooseKat->setGeometry(QRect(690, 20, 221, 25));
        tabWidget->addTab(ChislennostPage, QString());
        MainWindow->setCentralWidget(centralwidget);
        menubar = new QMenuBar(MainWindow);
        menubar->setObjectName(QString::fromUtf8("menubar"));
        menubar->setGeometry(QRect(0, 0, 1406, 22));
        MainWindow->setMenuBar(menubar);
        statusbar = new QStatusBar(MainWindow);
        statusbar->setObjectName(QString::fromUtf8("statusbar"));
        MainWindow->setStatusBar(statusbar);

        retranslateUi(MainWindow);

        tabWidget->setCurrentIndex(3);


        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QCoreApplication::translate("MainWindow", "MainWindow", nullptr));
        pushButton->setText(QCoreApplication::translate("MainWindow", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        pushButton_2->setText(QCoreApplication::translate("MainWindow", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
        pushButton_3->setText(QCoreApplication::translate("MainWindow", "\320\237\320\276\320\264\321\202\320\262\320\265\321\200\320\264\320\270\321\202\321\214", nullptr));
        pushButton_4->setText(QCoreApplication::translate("MainWindow", "\320\236\321\202\320\274\320\265\320\275\320\270\321\202\321\214", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(KafedraPage), QCoreApplication::translate("MainWindow", "\320\232\320\260\321\204\320\265\320\264\321\200\320\260", nullptr));
        pushButton_5->setText(QCoreApplication::translate("MainWindow", "\320\236\321\202\320\274\320\265\320\275\320\270\321\202\321\214", nullptr));
        pushButton_6->setText(QCoreApplication::translate("MainWindow", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        pushButton_7->setText(QCoreApplication::translate("MainWindow", "\320\237\320\276\320\264\321\202\320\262\320\265\321\200\320\264\320\270\321\202\321\214", nullptr));
        pushButton_8->setText(QCoreApplication::translate("MainWindow", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(ValuePage), QCoreApplication::translate("MainWindow", "\320\227\320\275\320\260\321\207\320\265\320\275\320\270\320\265", nullptr));
        pushButton_12->setText(QCoreApplication::translate("MainWindow", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
        pushButton_9->setText(QCoreApplication::translate("MainWindow", "\320\236\321\202\320\274\320\265\320\275\320\270\321\202\321\214", nullptr));
        pushButton_10->setText(QCoreApplication::translate("MainWindow", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        pushButton_11->setText(QCoreApplication::translate("MainWindow", "\320\237\320\276\320\264\321\202\320\262\320\265\321\200\320\264\320\270\321\202\321\214", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(KategoriaPage), QCoreApplication::translate("MainWindow", "\320\232\320\260\321\202\320\265\320\263\320\276\321\200\320\270\321\217", nullptr));
        pushButton_13->setText(QCoreApplication::translate("MainWindow", "\320\236\321\202\320\274\320\265\320\275\320\270\321\202\321\214", nullptr));
        pushButton_14->setText(QCoreApplication::translate("MainWindow", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        pushButton_15->setText(QCoreApplication::translate("MainWindow", "\320\237\320\276\320\264\321\202\320\262\320\265\321\200\320\264\320\270\321\202\321\214", nullptr));
        pushButton_16->setText(QCoreApplication::translate("MainWindow", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(YearPage), QCoreApplication::translate("MainWindow", "\320\223\320\276\320\264", nullptr));
        pushButton_17->setText(QCoreApplication::translate("MainWindow", "\320\236\321\202\320\274\320\265\320\275\320\270\321\202\321\214", nullptr));
        pushButton_18->setText(QCoreApplication::translate("MainWindow", "\320\224\320\276\320\261\320\260\320\262\320\270\321\202\321\214", nullptr));
        pushButton_19->setText(QCoreApplication::translate("MainWindow", "\320\237\320\276\320\264\321\202\320\262\320\265\321\200\320\264\320\270\321\202\321\214", nullptr));
        pushButton_20->setText(QCoreApplication::translate("MainWindow", "\320\243\320\264\320\260\320\273\320\270\321\202\321\214", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(ChislennostPage), QCoreApplication::translate("MainWindow", "\320\247\320\270\321\201\320\273\320\265\320\275\320\275\320\276\321\201\321\202\321\214", nullptr));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
