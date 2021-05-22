#include "uch_plan.h"
#include "ui_uch_plan.h"

Uch_Plan::Uch_Plan(QSqlDatabase _db, QWidget *parent) : QDialog(parent), ui(new Ui::Uch_Plan)
{
    ui->setupUi(this);
    db = _db;

    uch_planTable = new QSqlRelationalTableModel(0, db);
    specTable = new QSqlRelationalTableModel(0, db);

    uch_planTable->setTable("uch_plan");
    specTable->setTable("speciality");

    uch_planTable->select();
    specTable->select();

    ui->specialityTableView->setModel(specTable);
    ui->uch_planTableView->setModel(uch_planTable);
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

    uch_planTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Наименование уч плана"), Qt::DisplayRole);
    uch_planTable->setHeaderData(2, Qt::Horizontal, QObject::tr("ID Специальности"), Qt::DisplayRole);
    specTable->setHeaderData(0, Qt::Horizontal, QObject::tr("ID"), Qt::DisplayRole);
    specTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Специальность"), Qt::DisplayRole);


    uch_planTable->select();
    specTable->select();

    ui->specialityTableView->setModel(specTable);
    ui->uch_planTableView->setModel(uch_planTable);
    ui->uch_planTableView->hideColumn(0);
    ui->specialityTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    ui->uch_planTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
}
