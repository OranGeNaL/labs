#include "gupr.h"
#include "ui_gupr.h"
#include <QSqlQuery>
#include <QDebug>
#include <QMessageBox>
#include <QSqlError>

Gupr::Gupr(QSqlDatabase _db, QWidget *parent) :
    QDialog(parent),
    ui(new Ui::Gupr)
{
    ui->setupUi(this);
    db = _db;

    guprTable = new QSqlRelationalTableModel(0, db);
    gupr_elTable = new QSqlRelationalTableModel(0, db);
    coursesTable = new QSqlQueryModel;

    coursesTable->setQuery("select distinct number_course from gupr");

    guprTable->setTable("gupr");
    gupr_elTable->setTable("gupr_elem");

    guprTable->select();
    gupr_elTable->select();

    ui->guprTableView->setModel(guprTable);
    //ui->guprCourse->setModel(guprTable);
    ui->guprCourse->setModel(coursesTable);

    ui->guprTableView->setSelectionBehavior(QAbstractItemView::SelectRows);

    formAdd = new ExtensibleAdd();

    connect(formAdd, SIGNAL(sendPositive()), this,
    SLOT(Add()));
    connect(formAdd, SIGNAL(sendNegative()),
    this, SLOT(Dismiss()));

    connect(ui->guprCourse->selectionModel(), SIGNAL(currentRowChanged(QModelIndex, QModelIndex)), this, SLOT(currentGuprChanged(QModelIndex, QModelIndex)));
}

Gupr::~Gupr()
{
    delete ui;
}

void Gupr::Update()
{
    guprTable = new QSqlRelationalTableModel(0, db);
    gupr_elTable = new QSqlRelationalTableModel(0, db);
    coursesTable = new QSqlQueryModel;

    coursesTable->setQuery("select distinct number_course from gupr");

    guprTable->setTable("gupr");
    gupr_elTable->setTable("gupr");

    guprTable->setEditStrategy(QSqlTableModel::OnManualSubmit);

    guprTable->setHeaderData(0, Qt::Horizontal, QObject::tr("Начало периода"), Qt::DisplayRole);
    guprTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Курс"), Qt::DisplayRole);
    guprTable->setHeaderData(2, Qt::Horizontal, QObject::tr("Количество недель"), Qt::DisplayRole);
    guprTable->setHeaderData(3, Qt::Horizontal, QObject::tr("Наименование ГУПР"), Qt::DisplayRole);
    //gupr_elTable->setHeaderData(0, Qt::Horizontal, QObject::tr("ID ГУПР"), Qt::DisplayRole);
    coursesTable->setHeaderData(0, Qt::Horizontal, QObject::tr("Курс"), Qt::DisplayRole);

    guprTable->setRelation(3, QSqlRelation("gupr_elem", "id_gupr_elem", "name_gupr_elem"));



    guprTable->select();
    gupr_elTable->select();

    ui->guprTableView->setModel(guprTable);
    //ui->guprCourse->setModel(gupr_elTable);
    ui->guprCourse->setModel(coursesTable);

    ui->guprTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    ui->guprCourse->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);

//    ui->guprCourse->setEditTriggers(QAbstractItemView::NoEditTriggers);

//    ui->guprCourse->hideColumn(0);
//    ui->guprCourse->hideColumn(2);
//    ui->guprCourse->hideColumn(3);
//    ui->guprCourse->hideColumn(4);
    ui->guprTableView->hideColumn(4);
    ui->guprTableView->hideColumn(1);

    connect(ui->guprCourse->selectionModel(), SIGNAL(currentRowChanged(QModelIndex, QModelIndex)), this, SLOT(currentGuprChanged(QModelIndex, QModelIndex)));
}

void Gupr::SetDB(QSqlDatabase _db)
{
    db = _db;
    Update();
}

void Gupr::Add()
{
    QSqlQuery query("select id_gupr_elem from gupr_elem where name_gupr_elem='" + formAdd->arg3 + "';");
    qDebug() << "select id_gupr_elem from gupr_elem where name_gupr_elem='" + formAdd->arg3 + "';";
    query.next();
    QString str = query.value(0).toString();/*
    int pos = str.lastIndexOf(QChar('"'));
    str = str.left(pos);
    pos = str.lastIndexOf(QChar('"'));
    str = str.right(pos);*/
   // qDebug() << str;

    QString select = "select insertintogupr(" + formAdd->arg1 + ", " + formAdd->arg4 + ", " + formAdd->arg2 + ", " + str + ", " + QString::number(idPlan) + ")";
    db.exec(select);
    qDebug() << select;


//    guprTable->select();
//    gupr_elTable->select();

    UpdateFilter();
    /*QMessageBox::critical(this, tr("ERROR!"),
    db.lastError().databaseText());*/

    formAdd->hide();
}

void Gupr::Dismiss()
{
    formAdd->hide();
}

void Gupr::on_addButton_clicked()
{
    formAdd->Set("Длительность", "Количество недель", "Элемент ГУПР", "Курс");
    formAdd->SetInput(0, 0, 1, 0);
    formAdd->SetCombo(2, "gupr_elem", "name_gupr_elem");
    formAdd->SetAddName("Добавить ГУПР");
    formAdd->show();
}


void Gupr::on_delButton_clicked()
{
    QModelIndex ind;
    QModelIndexList guprList = ui->guprTableView->selectionModel()->selectedRows(0);

    if(guprList.count() > 0)
    {
        int row = guprList.first().row();
        qDebug() << row;
        guprTable->removeRow(row, ind);

        if(!guprTable->submitAll())
        {
            QMessageBox::critical(this, tr("ERROR!"), db.lastError().databaseText());
        }
    }
}

void Gupr::currentGuprChanged(QModelIndex cur_ind, QModelIndex)
{
    //qDebug() << "CHANGED";
    if(cur_ind.isValid())
    {
        QSqlRecord record = gupr_elTable->record(cur_ind.row());
        currentCourse = record.value("number_course").toInt();
        //QString id = record.value("");
        //qDebug() << QString("gupr.number_course=%1").arg(record.value("number_course").toInt());
        //guprTable->setFilter(QString("gupr.number_course=%1").arg(record.value("number_course").toInt()));
    }
    else
    {
        //guprTable->setFilter("gupr.number_course=-1");
        currentCourse = -1;
    }

    UpdateFilter();
}

void Gupr::SetHeader(QString plan, QString speciality)
{
    Gupr::setWindowTitle("ГУПР для плана " + plan + " специальности " + speciality);
//    ui->planLabel->setText(plan);
//    ui->specLabel->setText(speciality);
}

void Gupr::SetParams(int spec, int plan)
{
    idSpec = spec;
    idPlan = plan;
    //idDisc = discTable->record(ui->discCombo->currentIndex()).field("id_disc").value().toInt();

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

void Gupr::UpdateFilter()
{
    QString filter = "gupr.uch_plan_id_gupr=" + QString::number(idPlan) + " AND gupr.number_course=" + QString::number(currentCourse);
    qDebug() << filter;
    guprTable->setFilter(filter);
    guprTable->select();
}
