#ifndef GRUPPA_H
#define GRUPPA_H

#include <QDialog>
#include <QSqlDatabase>
#include <QMessageBox>
#include <QSqlRelationalTableModel>
#include <QSqlRecord>
#include <QSqlQuery>
#include <QSqlField>
#include <QSqlError>

#include <extensibleadd.h>

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
    void SetDB(QSqlDatabase _db);

    QSqlDatabase db;

    ExtensibleAdd* formAdd;

    QSqlRelationalTableModel* gruppaTable;
    QSqlRelationalTableModel* uchPlanBox;
    QSqlRelationalTableModel* specialityBox;

private slots:
    void on_specialityCombo_currentIndexChanged(int index);
    void on_uch_planCombo_currentIndexChanged(int index);
    void Add();
    void Dismiss();

    void on_addButton_clicked();

    void on_delButton_clicked();

private:
    Ui::Gruppa *ui;
};

#endif // GRUPPA_H
