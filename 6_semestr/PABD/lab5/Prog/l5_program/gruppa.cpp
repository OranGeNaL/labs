#include "gruppa.h"
#include "ui_gruppa.h"
#include <QDebug>

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

    formAdd = new ExtensibleAdd();

    connect(formAdd, SIGNAL(sendPositive()), this,
    SLOT(Add()));
    connect(formAdd, SIGNAL(sendNegative()),
    this, SLOT(Dismiss()));
}

Gruppa::~Gruppa()
{
    delete ui;
}

void Gruppa::SetDB(QSqlDatabase _db)
{
    db = _db;
    Update();
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

    gruppaTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Группа"), Qt::DisplayRole);
    gruppaTable->setHeaderData(2, Qt::Horizontal, QObject::tr("Дата вступления"), Qt::DisplayRole);
//    gruppaTable->setFilter();

    ui->specialityCombo->setModel(specialityBox);
    ui->uch_planCombo->setModel(uchPlanBox);
    ui->groupTableView->setModel(gruppaTable);

    ui->groupTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    ui->groupTableView->hideColumn(0);
    ui->groupTableView->hideColumn(3);
    ui->groupTableView->hideColumn(4);

    ui->specialityCombo->setModelColumn(specialityBox->fieldIndex("name_spec"));
    ui->uch_planCombo->setModelColumn(uchPlanBox->fieldIndex("name_uch"));


}

void Gruppa::on_specialityCombo_currentIndexChanged(int index)
{

    QMessageBox msg;
    msg.setText("uch_plan.speciality_id_spec=" + specialityBox->record(index).field("id_spec").value().toString());
    //msg.exec();
    uchPlanBox->setFilter("uch_plan.speciality_id_spec=" + specialityBox->record(index).field("id_spec").value().toString());
    uchPlanBox->select();
    gruppaTable->select();
    //Update();
}


void Gruppa::on_uch_planCombo_currentIndexChanged(int index)
{

    gruppaTable->setFilter("gruppa.uch_plan_id_uch=" + uchPlanBox->record(index).field("id_uch").value().toString() + " and gruppa.speciality_id_spec=" + specialityBox->record(ui->specialityCombo->currentIndex()).field("id_spec").value().toString());
    gruppaTable->select();
    //Update();
}


void Gruppa::on_addButton_clicked()
{
    formAdd->Set("Наименование Группы", "Дата вступления", "ID Учебного Плана", "ID Специальности");
    formAdd->show();
}

void Gruppa::Add()
{
    QSqlQuery query("select id_uch from uch_plan where name_uch='" + formAdd->arg3 + "';");
    query.next();
    QString str1 = query.value(0).toString();

    QSqlQuery query2("select id_spec from speciality where name_spec='" + formAdd->arg4 + "';");
    query2.next();
    QString str2 = query2.value(0).toString();

    qDebug() << str1;
    qDebug() << str2;

    db.exec("select insertintogruppa('" + formAdd->arg1 + "', '" + formAdd->arg2 + "', " + str1 + ", " + str2 + ")");
    uchPlanBox->select();
    gruppaTable->select();
    specialityBox->select();

    /*QMessageBox::critical(this, tr("ERROR!"),
    db.lastError().databaseText());*/

    formAdd->hide();
}

void Gruppa::Dismiss()
{
    formAdd->hide();
}
