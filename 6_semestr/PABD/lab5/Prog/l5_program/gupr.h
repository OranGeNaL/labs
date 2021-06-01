#ifndef GUPR_H
#define GUPR_H

#include <QDialog>
#include <QSqlDatabase>
#include <QSqlRecord>
#include <QSqlRelationalTableModel>
#include <QSqlQueryModel>

#include <extensibleadd.h>

namespace Ui {
class Gupr;
}

class Gupr : public QDialog
{
    Q_OBJECT

public:
    explicit Gupr(QSqlDatabase _db, QWidget *parent = nullptr);
    ~Gupr();
    void Update();
    void SetDB(QSqlDatabase _db);
    void SetHeader(QString plan, QString speciality);
    void SetParams(int spec, int plan);
    void UpdateFilter();
    int idSpec;
    int idPlan;
    int idDisc;
    int currentCourse;

    QSqlDatabase db;

    ExtensibleAdd* formAdd;

private slots:
    void Add();
    void Dismiss();
    void currentGuprChanged(QModelIndex cur_ind, QModelIndex previous);

    void on_addButton_clicked();

    void on_delButton_clicked();

private:
    Ui::Gupr *ui;

    QSqlRelationalTableModel* guprTable;
    QSqlRelationalTableModel* gupr_elTable;
    QSqlQueryModel* coursesTable;
};

#endif // GUPR_H
