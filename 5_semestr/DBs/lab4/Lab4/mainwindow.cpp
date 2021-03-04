#include "ui_mainwindow.h"
#include "mainwindow.h"
#include <LimeReport>

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

    //QString filename = "/home/orangenal/Документы/labs/5_semestr/DB's/lab2/Lab2/base3-02.db";
    //QString filename = "/home/orangenal/Документы/labs/5_semestr/DB's/lab3/Lab3/base-new-un.db";
    QString filename = "/home/orangenal/Documents/labs/5_semestr/DBs/lab4/Lab4/base-cascade";

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
    Chislennost = new QSqlRelationalTableModel(0, db);
    Chislennost->setTable("Chislennost");

    /*Chislennost->setRelation(2, QSqlRelation("Kafedra", "Kaf_ID", "Kaf_name"));
    Chislennost->setRelation(3, QSqlRelation("Value", "Val_ID", "Val_name"));
    Chislennost->setRelation(4, QSqlRelation("Kategoria", "Kateg_ID", "Kateg_name"));

    ui->ChislennostView->setItemDelegate(new QSqlRelationalDelegate(ui->ChislennostView));*/
    ui->ChislennostView->setModel(Chislennost);
    ui->ChislennostView->setColumnHidden(0, true);
    ui->ChislennostView->setColumnHidden(2, true);
    ui->ChislennostView->setColumnHidden(3, true);
    ui->ChislennostView->setColumnHidden(4, true);
    Chislennost->setEditStrategy(QSqlTableModel::OnManualSubmit);

//    Kafedra_SUB = new QSqlQueryModel(0);
//    ui->KafedraRefView->setModel(Kafedra_SUB);

//    Value_SUB = new QSqlQueryModel(0);
//    ui->ValueRefView->setModel(Value_SUB);

//    Kategoria_SUB = new QSqlQueryModel(0);
//    ui->KategoriaRefView->setModel(Kategoria_SUB);

//    Year_SUB = new QSqlQueryModel(0);
//    ui->YearRefView->setModel(Year_SUB);

    initCB();
    updateFilter();
    UpdateDB();

    return 0;
}

bool MainWindow::warningDialog()
{
    QMessageBox msgBox;
    msgBox.setText("Удаление");
    msgBox.setInformativeText("Возможна потеря данных. Продолжить?");
    msgBox.setStandardButtons(QMessageBox::Yes | QMessageBox::No);
    msgBox.setDefaultButton(QMessageBox::Yes);
    msgBox.setEscapeButton(QMessageBox::No);
    int ret = msgBox.exec();

    return ret == QMessageBox::Yes;
}

void MainWindow::fillRecord(QSqlRecord &record)
{
    int curKaf, curVal, curKat;
    int ind;

    ind = ui->cbChooseKaf->currentIndex();
    curKaf = Kafedra->record(ind).field("Kaf_ID").value().toInt();

    ind = ui->cbChooseVal->currentIndex();
    curVal = Value->record(ind).field("Val_ID").value().toInt();

    ind = ui->cbChooseKat->currentIndex();
    curKat = Kategoria->record(ind).field("Kateg_ID").value().toInt();

    record = Chislennost->record();

    record.setValue("Kaf_ID", curKaf);
    record.setValue("Val_ID", curVal);
    record.setValue("Kateg_ID", curKat);
}

void MainWindow::initCB()
{
    ui->cbChooseKaf->setModel(Kafedra);
    ui->cbChooseKaf->setModelColumn(0);
    ui->cbChooseKaf->setCurrentIndex(0);

    ui->otchetCombo->setModel(Kafedra);
    ui->otchetCombo->setModelColumn(0);
    ui->otchetCombo->setCurrentIndex(0);


    ui->cbChooseVal->setModel(Value);
    ui->cbChooseVal->setModelColumn(0);
    ui->cbChooseVal->setCurrentIndex(0);

    ui->cbChooseKat->setModel(Kategoria);
    ui->cbChooseKat->setModelColumn(0);
    ui->cbChooseKat->setCurrentIndex(0);
}

bool MainWindow::testCB()
{
    bool b = true;
    b = b && (ui->cbChooseKaf->currentIndex() >= 0);
    b = b && (ui->cbChooseVal->currentIndex() >= 0);
    b = b && (ui->cbChooseKat->currentIndex() >= 0);

    return b;
}

void MainWindow::updateFilter()
{
    if(!testCB())
    {
        Chislennost->setFilter("");
        return;
    }

    QString stKaf, stVal, stKat;
    QString stFilter;
    int ind;



    ind = ui->cbChooseKaf->currentIndex();
    stKaf = Kafedra->record(ind).field("Kaf_ID").value().toString();

    ind = ui->cbChooseVal->currentIndex();
    stVal = Value->record(ind).field("Val_ID").value().toString();

    ind = ui->cbChooseKat->currentIndex();
    stKat = Kategoria->record(ind).field("Kateg_ID").value().toString();

    stFilter = "(Kaf_ID=" + stKaf + ") and ";
    stFilter += "(Val_ID=" + stVal + ") and ";
    stFilter += "(Kateg_ID=" + stKat + ")";

//    QMessageBox msgBox;
//    msgBox.setText(stFilter);
//    msgBox.exec();

    Chislennost->setFilter(stFilter);
}

void MainWindow::UpdateDB()
{
//    Kafedra_SUB->setQuery("SELECT * FROM Kafedra");
//    Value_SUB->setQuery("SELECT * FROM Value");
//    Kategoria_SUB->setQuery("SELECT * FROM Kategoria");
//    Year_SUB->setQuery("SELECT * FROM _Year");

    Chislennost->select();
    /*Chislennost->relationModel(2)->select();
    Chislennost->relationModel(3)->select();
    Chislennost->relationModel(4)->select();*/
}

//Kafedra page
void MainWindow::on_pushButton_clicked()
{
    QSqlRecord rec;
    Kafedra->insertRecord(-1, rec);
}

void MainWindow::on_pushButton_2_clicked()
{
    if(!warningDialog()) return;

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
    if(!warningDialog()) return;

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
    if(!warningDialog()) return;

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
    if(!warningDialog()) return;

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
    if(!testCB()) return;

    fillRecord(rec);
    Chislennost->insertRecord(-1, rec);
}

void MainWindow::on_pushButton_20_clicked()
{
    int _Row;
    if (ui->ChislennostView->selectionModel()->currentIndex().isValid())
    {
        _Row = ui->ChislennostView->selectionModel()->currentIndex().row();
        Chislennost->removeRow(_Row);

//        QMessageBox msgBox;
//        msgBox.setText("Текст");
//        msgBox.exec();
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

//void MainWindow::on_cbChooseKaf_currentIndexChanged(const QString &arg1)
//{
//    updateFilter();
//}

//void MainWindow::on_cbChooseVal_currentIndexChanged(const QString &arg1)
//{
//    updateFilter();
//}

//void MainWindow::on_cbChooseKat_currentIndexChanged(const QString &arg1)
//{
//    updateFilter();
//}

void MainWindow::on_cbChooseKaf_currentIndexChanged(int index)
{
    updateFilter();
}

void MainWindow::on_cbChooseVal_currentIndexChanged(int index)
{
    updateFilter();
}

void MainWindow::on_cbChooseKat_currentIndexChanged(int index)
{
    updateFilter();
}

void MainWindow::on_generateButton_clicked() // Кнопка отчета
{
    LimeReport::ReportEngine report;
    report.loadFromFile("/home/orangenal/Documents/labs/5_semestr/DBs/lab4/Lab4/report.lrxml");
    report.previewReport();


}
