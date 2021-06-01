#ifndef UCH_LOAD_H
#define UCH_LOAD_H

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
class Uch_Load;
}

class Uch_Load : public QDialog
{
    Q_OBJECT

public:
    explicit Uch_Load(QSqlDatabase _db, QWidget *parent = nullptr);
    void Update();
    void SetDB(QSqlDatabase _db);
    void SetHeader(QString plan, QString speciality);
    void SetParams(int spec, int plan);
    void UpdateFilter();
    int idSpec;
    int idPlan;
    int idDisc;
    ~Uch_Load();

private slots:
    void Add();
    void Dismiss();

    void on_discCombo_currentIndexChanged(int index);

    void on_addButton_clicked();

    void on_delButton_clicked();

private:
    Ui::Uch_Load *ui;
    QSqlDatabase db;

    ExtensibleAdd* formAdd;

    QSqlRelationalTableModel* discTable;
    QSqlRelationalTableModel* uch_loadTable;
};

#endif // UCH_LOAD_H
