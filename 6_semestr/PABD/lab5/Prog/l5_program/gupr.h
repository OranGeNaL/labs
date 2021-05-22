#ifndef GUPR_H
#define GUPR_H

#include <QDialog>
#include <QSqlDatabase>
#include <QSqlRelationalTableModel>

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

private:
    Ui::Gupr *ui;
    QSqlDatabase db;

    QSqlRelationalTableModel* guprTable;
    QSqlRelationalTableModel* gupr_elTable;
};

#endif // GUPR_H
