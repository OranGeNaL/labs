#include "kaf_rasp.h"
#include "ui_kaf_rasp.h"

Kaf_Rasp::Kaf_Rasp(QSqlDatabase _db, QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Kaf_Rasp)
{
    ui->setupUi(this);

    db = _db;

    kaf_raspTable = new QSqlRelationalTableModel(0, db);

    kafedraTable = new QSqlRelationalTableModel(0, db);
    specialityTable = new QSqlRelationalTableModel(0, db);
    disciplineTable = new QSqlRelationalTableModel(0, db);

    kaf_raspTable->setTable("kaf_rasp");

    kafedraTable->setTable("kafedra");
    specialityTable->setTable("speciality");
    disciplineTable->setTable("discipline");

    ui->kaf_raspTableView->setSelectionBehavior(QAbstractItemView::SelectRows);
    formAdd = new ExtensibleAdd();

    connect(formAdd, SIGNAL(sendPositive()), this,
    SLOT(Add()));
    connect(formAdd, SIGNAL(sendNegative()),
    this, SLOT(Dismiss()));

    /*ui->specialityCombo->setModel(specialityBox);
    ui->uch_planCombo->setModel(uchPlanBox);

    ui->specialityCombo->setModelColumn(1);
    ui->uch_planCombo->setModelColumn(1);

    formAdd = new ExtensibleAdd();

    connect(formAdd, SIGNAL(sendPositive()), this,
    SLOT(Add()));
    connect(formAdd, SIGNAL(sendNegative()),
    this, SLOT(Dismiss()));*/
}

void Kaf_Rasp::SetDB(QSqlDatabase _db)
{
    db = _db;
    Update();
}

void Kaf_Rasp::Update()
{
    kaf_raspTable = new QSqlRelationalTableModel(0, db);

    kafedraTable = new QSqlRelationalTableModel(0, db);
    specialityTable = new QSqlRelationalTableModel(0, db);
    disciplineTable = new QSqlRelationalTableModel(0, db);

    kaf_raspTable->setTable("kaf_rasp");

    kafedraTable->setTable("kafedra");
    specialityTable->setTable("speciality");
    disciplineTable->setTable("discipline");


    kaf_raspTable->setHeaderData(0, Qt::Horizontal, QObject::tr("Специальность"), Qt::DisplayRole);
    kaf_raspTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Дисциплина"), Qt::DisplayRole);
    kaf_raspTable->setHeaderData(2, Qt::Horizontal, QObject::tr("Кафедра"), Qt::DisplayRole);

    kaf_raspTable->select();
    kafedraTable->select();
    specialityTable->select();
    disciplineTable->select();

    kaf_raspTable->setRelation(1, QSqlRelation("discipline", "id_disc", "name_disc"));

    ui->kaf_raspTableView->setModel(kaf_raspTable);
    ui->kafedraCombo->setModel(kafedraTable);
    ui->specialityCombo->setModel(specialityTable);

    ui->kaf_raspTableView->hideColumn(0);
    ui->kaf_raspTableView->hideColumn(2);

    ui->kaf_raspTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);

    ui->kafedraCombo->setModelColumn(kafedraTable->fieldIndex("name_kaf"));
    ui->specialityCombo->setModelColumn(specialityTable->fieldIndex("name_spec"));
}

Kaf_Rasp::~Kaf_Rasp()
{
    delete ui;

}

void Kaf_Rasp::Add() {

    QSqlQuery query("select id_spec from speciality where name_spec='" + ui->specialityCombo->currentText()+ "';");
//    qDebug() << "select id_spec from speciality where name_spec='" + ui->specialityCombo->currentText()+ "';";
    query.next();
    QString spec_id = query.value(0).toString();

    QSqlQuery query1("select id_kaf from kafedra where name_kaf='" + ui->kafedraCombo->currentText()+ "';");
//    qDebug() << "select id_kaf from kafedra where name_kaf='" + ui->kafedraCombo->currentText()+ "';";
    query1.next();
    QString kaf_id = query1.value(0).toString();

    QSqlQuery query2("select id_disc from discipline where name_disc='" + formAdd->arg1+ "';");
//    qDebug() << "select id_disc from discipline where name_disc='" + formAdd->arg1+ "';";
    query2.next();
    QString disc_id = query2.value(0).toString();

    db.exec("select insertintokaf_rasp(" + spec_id + ", " + disc_id + ", " + kaf_id + ")");
//    qDebug() << "select insertintokaf_rasp(" + spec_id + ", " + disc_id + ", " + kaf_id + ")";
//    guprTable->select();
//    gupr_elTable->select();

    /*QMessageBox::critical(this, tr("ERROR!"),
    db.lastError().databaseText());*/
    kaf_raspTable->select();
    formAdd->hide();
}

void Kaf_Rasp::Dismiss(){
    formAdd->hide();
}

void Kaf_Rasp::on_addButton_clicked()
{
    formAdd->Set("Дисциплина", "", "", "");
    formAdd->SetInput(1, -1, -1, -1);
    formAdd->SetCombo(0, "discipline", "name_disc");
    formAdd->SetAddName("Добавить распределение");
    formAdd->show();
}

void Kaf_Rasp::UpdateFilter()
{
    QString filter = "kaf_rasp.Speciality_id_spec=" + specialityTable->record(ui->specialityCombo->currentIndex()).field("id_spec").value().toString() +
            " and kaf_rasp.Kafedra_id_kaf=" + kafedraTable->record(ui->kafedraCombo->currentIndex()).field("id_kaf").value().toString();
    //qDebug() << filter;
    kaf_raspTable->setFilter(filter);
}

void Kaf_Rasp::on_delButton_clicked()
{
    QModelIndex ind;
    int row = ui->kaf_raspTableView->selectionModel()->selectedRows(0).first().row();
    qDebug() << row;
    kaf_raspTable->removeRow(row, ind);

    if(!kaf_raspTable->submitAll())
    {
        QMessageBox::critical(this, tr("ERROR!"), db.lastError().databaseText());
    }
}


void Kaf_Rasp::on_kafedraCombo_currentIndexChanged(int index)
{
    UpdateFilter();
}


void Kaf_Rasp::on_specialityCombo_currentIndexChanged(int index)
{
    UpdateFilter();
}

