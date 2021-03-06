#ifndef KAF_RASP_H
#define KAF_RASP_H

#include <QDialog>
#include <QSqlDatabase>
#include <QSqlRelationalTableModel>
#include <QSqlRelation>
#include <QSqlRecord>
#include <QSqlField>
#include <QSqlQuery>
#include <QMessageBox>
#include <QSqlError>

#include <extensibleadd.h>

namespace Ui {
class Kaf_Rasp;
}

class Kaf_Rasp : public QDialog
{
    Q_OBJECT

public:
    explicit Kaf_Rasp(QSqlDatabase _db, QWidget *parent = nullptr);
    ~Kaf_Rasp();
    void Update();
    void SetDB(QSqlDatabase _db);
    ExtensibleAdd* formAdd;

private slots:
    void Add();
    void Dismiss();
    void on_addButton_clicked();

    void on_delButton_clicked();

    void on_kafedraCombo_currentIndexChanged(int index);

    void on_specialityCombo_currentIndexChanged(int index);

private:
    Ui::Kaf_Rasp *ui;

    QSqlDatabase db;
    void UpdateFilter();

    QSqlRelationalTableModel* kaf_raspTable;

    QSqlRelationalTableModel* specialityTable;
    QSqlRelationalTableModel* disciplineTable;
    QSqlRelationalTableModel* kafedraTable;
};

#endif // KAF_RASP_H
