#include "gupr.h"
#include "ui_gupr.h"

Gupr::Gupr(QSqlDatabase _db, QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Gupr)
{
    ui->setupUi(this);
    db = _db;

    guprTable = new QSqlRelationalTableModel(0, db);
    gupr_elTable = new QSqlRelationalTableModel(0, db);

    guprTable->setTable("gupr");
    gupr_elTable->setTable("gupr_elem");

    guprTable->select();
    gupr_elTable->select();

    ui->guprTableView->setModel(guprTable);
    ui->gupr_elTableView->setModel(gupr_elTable);
}

Gupr::~Gupr()
{
    delete ui;
}

void Gupr::Update()
{
    guprTable = new QSqlRelationalTableModel(0, db);
    gupr_elTable = new QSqlRelationalTableModel(0, db);

    guprTable->setTable("gupr");
    gupr_elTable->setTable("gupr_elem");

    guprTable->setHeaderData(0, Qt::Horizontal, QObject::tr("Длительность"), Qt::DisplayRole);
    guprTable->setHeaderData(1, Qt::Horizontal, QObject::tr("ID ГУПР"), Qt::DisplayRole);
    gupr_elTable->setHeaderData(0, Qt::Horizontal, QObject::tr("ID ГУПР"), Qt::DisplayRole);
    gupr_elTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Наименование ГУПР"), Qt::DisplayRole);


    guprTable->select();
    gupr_elTable->select();

    ui->guprTableView->setModel(guprTable);
    ui->gupr_elTableView->setModel(gupr_elTable);
    ui->guprTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    ui->gupr_elTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
}
