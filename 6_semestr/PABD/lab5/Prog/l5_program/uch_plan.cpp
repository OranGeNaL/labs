#include "uch_plan.h"
#include "ui_uch_plan.h"
#include <QSqlQuery>
#include <QDebug>
#include <QMessageBox>
#include <QSqlError>

Uch_Plan::Uch_Plan(QSqlDatabase _db, QWidget *parent) : QDialog(parent), ui(new Ui::Uch_Plan)
{
    ui->setupUi(this);
    db = _db;

    formAdd = new ExtensibleAdd();

    uch_planTable = new QSqlRelationalTableModel(0, db);
    specTable = new QSqlRelationalTableModel(0, db);

    uch_planTable->setTable("uch_plan");
    specTable->setTable("speciality");

    uch_planTable->select();
    specTable->select();

    ui->specialityTableView->setModel(specTable);
    ui->uch_planTableView->setModel(uch_planTable);

    ui->uch_planTableView->setSelectionBehavior(QAbstractItemView::SelectRows);

    connect(formAdd, SIGNAL(sendPositive()), this,
    SLOT(Add()));
    connect(formAdd, SIGNAL(sendNegative()),
    this, SLOT(Dismiss()));
}

Uch_Plan::~Uch_Plan()
{
    delete ui;
}

void Uch_Plan::Update()
{
    uch_planTable = new QSqlRelationalTableModel(0, db);
    specTable = new QSqlRelationalTableModel(0, db);

    uch_planTable->setTable("uch_plan");
    specTable->setTable("speciality");

    //uch_planTable->setHeaderData(0, Qt::Horizontal, QObject::tr("ID"), Qt::DisplayRole);
    uch_planTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Наименование уч плана"), Qt::DisplayRole);
    uch_planTable->setHeaderData(2, Qt::Horizontal, QObject::tr("Специальность"), Qt::DisplayRole);
    //specTable->setHeaderData(0, Qt::Horizontal, QObject::tr("ID"), Qt::DisplayRole);
    specTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Специальность"), Qt::DisplayRole);


    uch_planTable->setRelation(2, QSqlRelation("speciality", "id_spec", "name_spec"));

    uch_planTable->select();
    specTable->select();

    ui->specialityTableView->setModel(specTable);
    ui->uch_planTableView->setModel(uch_planTable);
//    ui->uch_planTableView->hideColumn(0);
    ui->uch_planTableView->hideColumn(0);
    ui->specialityTableView->hideColumn(0);
    ui->specialityTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    ui->uch_planTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
}

void Uch_Plan::SetDB(QSqlDatabase _db)
{
    db = _db;
    Update();
}

void Uch_Plan::Add()
{
    QSqlQuery query("select id_spec from speciality where name_spec='" + formAdd->arg2 + "';");
    query.next();
    QString str = query.value(0).toString();

    db.exec("select insertintouchplan('" + formAdd->arg1 + "', " + str + ")");
    uch_planTable->select();
    specTable->select();

    formAdd->hide();
}

void Uch_Plan::Dismiss()
{
    formAdd->hide();
}

void Uch_Plan::on_addButton_clicked()
{
    formAdd->Set("Наименование Уч. Плана", "Специальность", "", "");
    formAdd->show();
}


void Uch_Plan::on_delButton_clicked()
{

    QModelIndex ind;
    int row = ui->uch_planTableView->selectionModel()->selectedRows(0).first().row();
    qDebug() << row;
    uch_planTable->removeRow(row, ind);

    if(!uch_planTable->submitAll())
    {
        QMessageBox::critical(this, tr("ERROR!"), db.lastError().databaseText());
    }
}

