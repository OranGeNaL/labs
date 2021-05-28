#include "uch_load.h"
#include "ui_uch_load.h"

Uch_Load::Uch_Load(QSqlDatabase _db, QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Uch_Load)
{
    ui->setupUi(this);
    db = _db;

    formAdd = new ExtensibleAdd();

    discTable = new QSqlRelationalTableModel(0, db);
    uch_loadTable = new QSqlRelationalTableModel(0, db);

    discTable->setTable("discipline");
    uch_loadTable->setTable("uch_load");

    discTable->select();
    uch_loadTable->select();

    ui->discCombo->setModel(discTable);
    ui->uch_loadTableView->setModel(uch_loadTable);

    ui->uch_loadTableView->setSelectionBehavior(QAbstractItemView::SelectRows);
}

void Uch_Load::Update()
{
    //db = QSqlDatabase::database();

    discTable = new QSqlRelationalTableModel(0, db);
    uch_loadTable = new QSqlRelationalTableModel(0, db);

    discTable->setTable("discipline");
    uch_loadTable->setTable("uch_load");

    //uch_planTable->setHeaderData(0, Qt::Horizontal, QObject::tr("ID"), Qt::DisplayRole);
//    uch_planTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Наименование уч плана"), Qt::DisplayRole);
//    uch_planTable->setHeaderData(2, Qt::Horizontal, QObject::tr("Специальность"), Qt::DisplayRole);
    //specTable->setHeaderData(0, Qt::Horizontal, QObject::tr("ID"), Qt::DisplayRole);
//    specTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Специальность"), Qt::DisplayRole);


//    uch_planTable->setRelation(2, QSqlRelation("speciality", "id_spec", "name_spec"));

    discTable->select();
    uch_loadTable->select();

    ui->discCombo->setModel(discTable);
    ui->discCombo->setModelColumn(1);
    ui->uch_loadTableView->setModel(uch_loadTable);
//    ui->uch_planTableView->hideColumn(0);
//    ui->uch_planTableView->hideColumn(0);
//    ui->specialityTableView->hideColumn(0);
//    ui->specialityTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    ui->uch_loadTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);

//    connect(ui->specialityTableView->selectionModel(), SIGNAL(currentRowChanged(QModelIndex, QModelIndex)), this, SLOT(currentUch_PlanChanged(QModelIndex, QModelIndex)));
}

void Uch_Load::SetDB(QSqlDatabase _db)
{
    db = _db;
    Update();
}

Uch_Load::~Uch_Load()
{
    delete ui;
}

void Uch_Load::Add()
{

}

void Uch_Load::Dismiss()
{

}
