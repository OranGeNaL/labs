#ifndef GUPR_H
#define GUPR_H

#include <QDialog>
#include <QSqlDatabase>
#include <QSqlRelationalTableModel>

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

    QSqlDatabase db;

    ExtensibleAdd* formAdd;

private slots:
    void Add();
    void Dismiss();

    void on_addButton_clicked();

    void on_delButton_clicked();

private:
    Ui::Gupr *ui;

    QSqlRelationalTableModel* guprTable;
    QSqlRelationalTableModel* gupr_elTable;
};

#endif // GUPR_H
