#ifndef EXTENSIBLEADD_H
#define EXTENSIBLEADD_H

#include <QDialog>
#include <QSqlDatabase>
#include <QDebug>
#include <QSqlRelationalTableModel>

namespace Ui {
class ExtensibleAdd;
}

class ExtensibleAdd : public QDialog
{
    Q_OBJECT

public:
    explicit ExtensibleAdd(QWidget *parent = nullptr);
    ~ExtensibleAdd();

    void Set(QString, QString, QString, QString);
    void SetInput(int, int, int, int);
    void SetCombo(int, QString, QString);
    void SetAddName(QString);
    QString arg1;
    QString arg2;
    QString arg3;
    QString arg4;

    QString** comboParams;
    QSqlRelationalTableModel **tables;

    int* inputsState;

signals:
    void sendPositive();
    void sendNegative();
private slots:
    void on_addButton_clicked();
    void on_cancelButton_clicked();

private:
    void InputChange(int, int);
    Ui::ExtensibleAdd *ui;
};

#endif // EXTENSIBLEADD_H
