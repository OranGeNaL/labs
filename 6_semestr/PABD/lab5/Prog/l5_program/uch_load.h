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
    ~Uch_Load();

private slots:
    void Add();
    void Dismiss();

private:
    Ui::Uch_Load *ui;
    QSqlDatabase db;

    ExtensibleAdd* formAdd;

    QSqlRelationalTableModel* discTable;
    QSqlRelationalTableModel* uch_loadTable;
};

#endif // UCH_LOAD_H
