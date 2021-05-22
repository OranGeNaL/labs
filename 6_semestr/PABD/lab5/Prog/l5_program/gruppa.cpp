#include "gruppa.h"
#include "ui_gruppa.h"

Gruppa::Gruppa(QSqlDatabase _db, QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Gruppa)
{
    ui->setupUi(this);

    db = _db;

    gruppaTable = new QSqlRelationalTableModel(0, db);
    specialityBox = new QSqlRelationalTableModel(0, db);
    uchPlanBox = new QSqlRelationalTableModel(0, db);

    uchPlanBox->setTable("uch_plan");
    specialityBox->setTable("speciality");
    gruppaTable->setTable("gruppa");

    uchPlanBox->select();
    specialityBox->select();

    ui->specialityCombo->setModel(specialityBox);
    ui->uch_planCombo->setModel(uchPlanBox);

    ui->specialityCombo->setModelColumn(1);
    ui->uch_planCombo->setModelColumn(1);
}

Gruppa::~Gruppa()
{
    delete ui;
}

void Gruppa::Update()
{
    gruppaTable = new QSqlRelationalTableModel(0, db);
    specialityBox = new QSqlRelationalTableModel(0, db);
    uchPlanBox = new QSqlRelationalTableModel(0, db);

    uchPlanBox->setTable("uch_plan");
    specialityBox->setTable("speciality");
    gruppaTable->setTable("gruppa");

    uchPlanBox->select();
    specialityBox->select();
    gruppaTable->select();
//    gruppaTable->setFilter();

    ui->specialityCombo->setModel(specialityBox);
    ui->uch_planCombo->setModel(uchPlanBox);
    ui->groupTableView->setModel(gruppaTable);

    ui->groupTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);

    ui->specialityCombo->setModelColumn(specialityBox->fieldIndex("name_spec"));
    ui->uch_planCombo->setModelColumn(uchPlanBox->fieldIndex("name_uch"));

}
