#ifndef UCH_PLAN_H
#define UCH_PLAN_H

#include <QDialog>
#include <QSqlDatabase>
#include <QSqlRelationalTableModel>
#include <QSqlRecord>

#include <extensibleadd.h>
#include <uch_load.h>
#include <gupr.h>
#include <QException>

namespace Ui {
class Uch_Plan;
}

class Uch_Plan : public QDialog
{
    Q_OBJECT

public:
    explicit Uch_Plan(QSqlDatabase _db, QWidget *parent = nullptr);
    ~Uch_Plan();
    void Update();
    void SetDB(QSqlDatabase _db);
    Uch_Load* formUch_Load;
    Gupr* formGupr;

private slots:
    void Add();
    void Dismiss();
    void currentUch_PlanChanged(QModelIndex cur_ind, QModelIndex previous);

    void on_addButton_clicked();

    void on_delButton_clicked();

    void on_redLoadButton_clicked();

    void on_redGuprButton_clicked();

private:
    Ui::Uch_Plan *ui;
    QSqlDatabase db;

    ExtensibleAdd* formAdd;

    QSqlRelationalTableModel* specTable;
    QSqlRelationalTableModel* uch_planTable;
};

#endif // UCH_PLAN_H
