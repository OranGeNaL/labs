#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QtSql>
#include <QMessageBox>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    int initDB();
    void initCB();
    void UpdateDB();
    bool testCB();
    void updateFilter();
    void fillRecord(QSqlRecord &record);
    bool warningDialog();

private slots:
    void on_pushButton_clicked();

    void on_pushButton_2_clicked();

    void on_pushButton_3_clicked();

    void on_pushButton_4_clicked();

    void on_pushButton_6_clicked();

    void on_pushButton_8_clicked();

    void on_pushButton_7_clicked();

    void on_pushButton_5_clicked();

    void on_pushButton_11_clicked();

    void on_pushButton_10_clicked();

    void on_pushButton_12_clicked();

    void on_pushButton_9_clicked();

    void on_pushButton_14_clicked();

    void on_pushButton_16_clicked();

    void on_pushButton_15_clicked();

    void on_pushButton_13_clicked();

    void on_pushButton_18_clicked();

    void on_pushButton_20_clicked();

    void on_pushButton_19_clicked();

    void on_pushButton_17_clicked();

    void on_cbChooseKaf_currentIndexChanged(const QString &arg1);

    void on_cbChooseVal_currentIndexChanged(const QString &arg1);

    void on_cbChooseKat_currentIndexChanged(const QString &arg1);

    void on_cbChooseKaf_currentIndexChanged(int index);

    void on_cbChooseVal_currentIndexChanged(int index);

    void on_cbChooseKat_currentIndexChanged(int index);

private:
    Ui::MainWindow *ui;
    QSqlDatabase db;
    QSqlTableModel *Kafedra, *Value, *Kategoria, *_Year;
    QSqlRelationalTableModel *Chislennost;

    QSqlQueryModel *Kafedra_SUB, *Value_SUB, *Kategoria_SUB, *Year_SUB;
};
#endif // MAINWINDOW_H
