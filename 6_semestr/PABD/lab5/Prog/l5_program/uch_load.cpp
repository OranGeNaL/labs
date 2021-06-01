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

    connect(formAdd, SIGNAL(sendPositive()), this,
    SLOT(Add()));
    connect(formAdd, SIGNAL(sendNegative()),
    this, SLOT(Dismiss()));
}

void Uch_Load::Update()
{
    //db = QSqlDatabase::database();

    discTable = new QSqlRelationalTableModel(0, db);
    uch_loadTable = new QSqlRelationalTableModel(0, db);

    discTable->setTable("discipline");
    uch_loadTable->setTable("uch_load");


    discTable->select();
    uch_loadTable->select();

    ui->discCombo->setModel(discTable);
    ui->discCombo->setModelColumn(1);
    ui->uch_loadTableView->setModel(uch_loadTable);

    uch_loadTable->setHeaderData(0, Qt::Horizontal, QObject::tr("Часы"), Qt::DisplayRole);
    uch_loadTable->setHeaderData(3, Qt::Horizontal, QObject::tr("Семестр"), Qt::DisplayRole);

    ui->uch_loadTableView->hideColumn(1);
    ui->uch_loadTableView->hideColumn(2);
    ui->uch_loadTableView->hideColumn(4);
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

void Uch_Load::SetHeader(QString plan, QString speciality)
{
    Uch_Load::setWindowTitle("Учебная нагрузка для плана " + plan + " специальности " + speciality);
    ui->planLabel->setText(plan);
    ui->specLabel->setText(speciality);
}

void Uch_Load::SetParams(int spec, int plan)
{
    idSpec = spec;
    idPlan = plan;
    idDisc = discTable->record(ui->discCombo->currentIndex()).field("id_disc").value().toInt();

    //qDebug() << "select name_spec from speciality where speciality.id_spec=" + QString::number(spec);
    QSqlQuery query("select name_spec from speciality where speciality.id_spec=" + QString::number(spec));
    query.next();
    QString strSpec = query.value(0).toString();

    query.exec("select name_uch from uch_plan where uch_plan.id_uch=" + QString::number(plan));
    query.next();
    QString strPlan = query.value(0).toString();

    SetHeader(strPlan, strSpec);
    UpdateFilter();

}

void Uch_Load::Add()
{
//    QSqlQuery query("select id_spec from speciality where name_spec='" + formAdd->arg2 + "';");
//    query.next();
//    QString str = query.value(0).toString();

    db.exec("select insertintouch_load('" + formAdd->arg1 + "', " + QString::number(idPlan) + ", " + QString::number(idSpec) + ", " + formAdd->arg2 + ", " + QString::number(idDisc) + ")");

    UpdateFilter();

    formAdd->hide();
}

void Uch_Load::Dismiss()
{
    formAdd->hide();
}

void Uch_Load::on_discCombo_currentIndexChanged(int index)
{
    idDisc = discTable->record(index).field("id_disc").value().toInt();
    UpdateFilter();
}

void Uch_Load::UpdateFilter()
{
    QString filter = "uch_load.Uch_Plan_id_uch=" + QString::number(idPlan) + " AND uch_load.Speciality_id_spec=" + QString::number(idSpec) +
            " AND uch_load.Discipline_id_disc=" + QString::number(idDisc);

    qDebug() << filter;

    uch_loadTable->setFilter(filter);
    uch_loadTable->select();
}

void Uch_Load::on_addButton_clicked()
{
    formAdd->Set("Количество часов", "Семестр", "", "");
    formAdd->SetInput(0, 0, -1, -1);
    formAdd->SetAddName("Добавить учебную нагрузку");
    formAdd->show();
}


void Uch_Load::on_delButton_clicked()
{
    QModelIndex ind;
    QModelIndexList uch_loadList = ui->uch_loadTableView->selectionModel()->selectedRows(0);
    if(uch_loadList.count() > 0)
    {
        int row = uch_loadList.first().row();
        //qDebug() << row;
        uch_loadTable->removeRow(row, ind);

        if(!uch_loadTable->submitAll())
        {
            QMessageBox::critical(this, tr("ERROR!"), db.lastError().databaseText());
        }
    }
}

