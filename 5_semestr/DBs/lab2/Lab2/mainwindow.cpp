#include "ui_mainwindow.h"
#include "mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    if(initDB() == 1)
        exit(EXIT_FAILURE);
}

MainWindow::~MainWindow()
{
    delete ui;
}

int MainWindow::initDB()
{
    db = QSqlDatabase::addDatabase("QSQLITE");

    QString filename = "/home/orangenal/Документы/labs/5_semestr/DB's/lab2/Lab2/base3-02.db";

    db.setDatabaseName(filename);
    if (QFileInfo::exists(filename))
    {
        db.open();
        db.exec("pragma foreign_keys=on");
    }
    else
    {
        QMessageBox::critical(this, "Error", "Can not open database");
        return 1;
    }


    ui->KafedraView->setWindowTitle("Kafedra");
    ui->KafedraView->show();
    Kafedra = new QSqlTableModel(0, db);
    Kafedra->setTable("Kafedra");
    Kafedra->select();
    ui->KafedraView->setModel(Kafedra);
    Kafedra->setEditStrategy(QSqlTableModel::OnManualSubmit);

    ui->ValueView->setWindowTitle("Value");
    ui->ValueView->show();
    Value = new QSqlTableModel(0, db);
    Value->setTable("Value");
    Value->select();
    ui->ValueView->setModel(Value);
    Value->setEditStrategy(QSqlTableModel::OnManualSubmit);

    ui->KategoriaView->setWindowTitle("Kategoria");
    ui->KategoriaView->show();
    Kategoria = new QSqlTableModel(0, db);
    Kategoria->setTable("Kategoria");
    Kategoria->select();
    ui->KategoriaView->setModel(Kategoria);
    Kategoria->setEditStrategy(QSqlTableModel::OnManualSubmit);

    ui->YearView->setWindowTitle("Year");
    ui->YearView->show();
    _Year = new QSqlTableModel(0, db);
    _Year->setTable("_Year");
    _Year->select();
    ui->YearView->setModel(_Year);
    _Year->setEditStrategy(QSqlTableModel::OnManualSubmit);

    ui->ChislennostView->setWindowTitle("Chislennost");
    ui->ChislennostView->show();
    Chislennost = new QSqlTableModel(0, db);
    Chislennost->setTable("Chislennost");
    Chislennost->select();
    ui->ChislennostView->setModel(Chislennost);
    Chislennost->setEditStrategy(QSqlTableModel::OnManualSubmit);

    Kafedra_SUB = new QSqlQueryModel(0);
    ui->KafedraRefView->setModel(Kafedra_SUB);

    Value_SUB = new QSqlQueryModel(0);
    ui->ValueRefView->setModel(Value_SUB);

    Kategoria_SUB = new QSqlQueryModel(0);
    ui->KategoriaRefView->setModel(Kategoria_SUB);

    Year_SUB = new QSqlQueryModel(0);
    ui->YearRefView->setModel(Year_SUB);

    UpdateDB();

    return 0;
}

void MainWindow::UpdateDB()
{
    Kafedra_SUB->setQuery("SELECT * FROM Kafedra");
    Value_SUB->setQuery("SELECT * FROM Value");
    Kategoria_SUB->setQuery("SELECT * FROM Kategoria");
    Year_SUB->setQuery("SELECT * FROM _Year");
}

//Kafedra page
void MainWindow::on_pushButton_clicked()
{
    QSqlRecord rec;
    Kafedra->insertRecord(-1, rec);
}

void MainWindow::on_pushButton_2_clicked()
{
    int _Row;
    if (ui->KafedraView->selectionModel()->currentIndex().isValid())
    {
        _Row = ui->KafedraView->selectionModel()->currentIndex().row();
        Kafedra->removeRow(_Row);
    }
}

void MainWindow::on_pushButton_3_clicked()
{
    if (Kafedra->submitAll())
    {
        UpdateDB();
    }
    else
    {
        QMessageBox::warning(this, "Error", Kafedra->lastError().databaseText());
    }
}

void MainWindow::on_pushButton_4_clicked()
{
    Kafedra->revertAll();
}

//Value page

void MainWindow::on_pushButton_6_clicked()
{
    QSqlRecord rec;
    Value->insertRecord(-1, rec);
}

void MainWindow::on_pushButton_8_clicked()
{
    int _Row;
    if (ui->ValueView->selectionModel()->currentIndex().isValid())
    {
        _Row = ui->ValueView->selectionModel()->currentIndex().row();
        Value->removeRow(_Row);
    }
}

void MainWindow::on_pushButton_7_clicked()
{
    if (Value->submitAll())
    {
        UpdateDB();
    }
    else
    {
        QMessageBox::warning(this, "Error", Value->lastError().databaseText());
    }
}

void MainWindow::on_pushButton_5_clicked()
{
    Value->revertAll();
}

//Kategoria page

void MainWindow::on_pushButton_10_clicked()
{
    QSqlRecord rec;
    Kategoria->insertRecord(-1, rec);
}

void MainWindow::on_pushButton_12_clicked()
{
    int _Row;
    if (ui->KategoriaView->selectionModel()->currentIndex().isValid())
    {
        _Row = ui->KategoriaView->selectionModel()->currentIndex().row();
        Kategoria->removeRow(_Row);
    }
}

void MainWindow::on_pushButton_11_clicked()
{
    if (Kategoria->submitAll())
    {
        UpdateDB();
    }
    else
    {
        QMessageBox::warning(this, "Error", Kategoria->lastError().databaseText());
    }
}

void MainWindow::on_pushButton_9_clicked()
{
    Kategoria->revertAll();
}

//Year page

void MainWindow::on_pushButton_14_clicked()
{
    QSqlRecord rec;
    _Year->insertRecord(-1, rec);
}

void MainWindow::on_pushButton_16_clicked()
{
    int _Row;
    if (ui->YearView->selectionModel()->currentIndex().isValid())
    {
        _Row = ui->YearView->selectionModel()->currentIndex().row();
        _Year->removeRow(_Row);
    }
}

void MainWindow::on_pushButton_15_clicked()
{
    if (_Year->submitAll())
    {
        UpdateDB();
    }
    else
    {
        QMessageBox::warning(this, "Error", _Year->lastError().databaseText());
    }
}

void MainWindow::on_pushButton_13_clicked()
{
    _Year->revertAll();
}

//Chislennost page

void MainWindow::on_pushButton_18_clicked()
{
    QSqlRecord rec;
    Chislennost->insertRecord(-1, rec);
}

void MainWindow::on_pushButton_20_clicked()
{
    int _Row;
    if (ui->ChislennostView->selectionModel()->currentIndex().isValid())
    {
        _Row = ui->ChislennostView->selectionModel()->currentIndex().row();
        Chislennost->removeRow(_Row);
    }
}

void MainWindow::on_pushButton_19_clicked()
{
    if (Chislennost->submitAll())
    {
        UpdateDB();
    }
    else
    {
        QMessageBox::warning(this, "Error", Chislennost->lastError().databaseText());
    }
}

void MainWindow::on_pushButton_17_clicked()
{
    Chislennost->revertAll();
}
