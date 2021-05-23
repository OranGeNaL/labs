#ifndef EXTENSIBLEADD_H
#define EXTENSIBLEADD_H

#include <QDialog>

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
    QString arg1;
    QString arg2;
    QString arg3;
    QString arg4;

signals:
    void sendPositive();
    void sendNegative();
private slots:
    void on_addButton_clicked();
    void on_cancelButton_clicked();

private:
    Ui::ExtensibleAdd *ui;
};

#endif // EXTENSIBLEADD_H
