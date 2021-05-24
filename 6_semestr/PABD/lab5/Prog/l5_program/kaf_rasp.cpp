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

    kaf_raspTable->select();
    kafedraTable->select();
    specialityTable->select();
    disciplineTable->select();

    //kaf_raspTable->setRelation(0, QSqlRelation("speciality", "Speciality_id_spec", "name_spec"));

    ui->kaf_raspTableView->setModel(kaf_raspTable);
    ui->kafedraCombo->setModel(kafedraTable);
    ui->disciplineCombo->setModel(disciplineTable);

    ui->kaf_raspTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);

    ui->kafedraCombo->setModelColumn(kafedraTable->fieldIndex("name_kaf"));
    ui->disciplineCombo->setModelColumn(disciplineTable->fieldIndex("name_disc"));
}

Kaf_Rasp::~Kaf_Rasp()
{
    delete ui;

}
