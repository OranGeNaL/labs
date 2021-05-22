#ifndef GRUPPA_H
#define GRUPPA_H

#include <QDialog>
#include <QSqlDatabase>
#include <QSqlRelationalTableModel>

namespace Ui {
class Gruppa;
}

class Gruppa : public QDialog
{
    Q_OBJECT

public:
    explicit Gruppa(QSqlDatabase _db, QWidget *parent = nullptr);
    ~Gruppa();
    void Update();

    QSqlDatabase db;

    QSqlRelationalTableModel* gruppaTable;
    QSqlRelationalTableModel* uchPlanBox;
    QSqlRelationalTableModel* specialityBox;

private:
    Ui::Gruppa *ui;
};

#endif // GRUPPA_H
