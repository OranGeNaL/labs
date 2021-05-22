#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QSqlDatabase>
#include <QMessageBox>
#include <QSqlError>
#include <QSqlRelationalTableModel>
#include <QDebug>

#include <authorization.h>
#include <uch_plan.h>
#include <gupr.h>
#include <gruppa.h>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    QSqlRelationalTableModel* model;

    Authorization* formAutorization;
    Uch_Plan* formUch_Plan;
    Gupr* formGupr;
    Gruppa* formGruppa;

    QMenu* mainMenu;
    QMenu* mainMenuTables;
    QMenu* otherMenuTables;

    QAction* actAuthorisation;
    QAction* actUch_Load;
    QAction* actCourse;
    QAction* actDiscipline;
    QAction* actSpeciality;
    QAction* actUch_Plan;
    QAction* actGruppa;
    QAction* actGupr;
    QAction* actGupr_elem;
    QAction* actKafedra;
    QAction* actKaf_Rasp;
    QAction* actSemestr;
    QAction* actNumber_Weeks;

private:
    Ui::MainWindow *ui;
    QSqlDatabase db;
    QSqlRelationalTableModel* table;
    void selectTable(QString nameTable);

    unsigned const_hash(char const *);

private slots:
    void Connect();
    void Disconnect();
    void OpenF(QAction*);
};
#endif // MAINWINDOW_H
