#ifndef UCH_PLAN_H
#define UCH_PLAN_H

#include <QDialog>
#include <QSqlDatabase>
#include <QSqlRelationalTableModel>

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

private:
    Ui::Uch_Plan *ui;
    QSqlDatabase db;

    QSqlRelationalTableModel* specTable;
    QSqlRelationalTableModel* uch_planTable;
};

#endif // UCH_PLAN_H
