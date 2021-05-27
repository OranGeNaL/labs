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

    guprTable->setTable("gupr");
    gupr_elTable->setTable("gupr_elem");

    guprTable->select();
    gupr_elTable->select();

    ui->guprTableView->setModel(guprTable);
    ui->gupr_elTableView->setModel(gupr_elTable);

    ui->guprTableView->setSelectionBehavior(QAbstractItemView::SelectRows);

    formAdd = new ExtensibleAdd();

    connect(formAdd, SIGNAL(sendPositive()), this,
    SLOT(Add()));
    connect(formAdd, SIGNAL(sendNegative()),
    this, SLOT(Dismiss()));
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

    guprTable->setEditStrategy(QSqlTableModel::OnManualSubmit);

    guprTable->setHeaderData(0, Qt::Horizontal, QObject::tr("Длительность"), Qt::DisplayRole);
    guprTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Наименование ГУПР"), Qt::DisplayRole);
    guprTable->setHeaderData(2, Qt::Horizontal, QObject::tr("Курс"), Qt::DisplayRole);
    guprTable->setHeaderData(3, Qt::Horizontal, QObject::tr("Количество недель"), Qt::DisplayRole);
    //gupr_elTable->setHeaderData(0, Qt::Horizontal, QObject::tr("ID ГУПР"), Qt::DisplayRole);
    gupr_elTable->setHeaderData(1, Qt::Horizontal, QObject::tr("Наименование ГУПР"), Qt::DisplayRole);

    guprTable->setRelation(1, QSqlRelation("gupr_elem", "id_gupr_elem", "name_gupr_elem"));


    guprTable->select();
    gupr_elTable->select();

    ui->guprTableView->setModel(guprTable);
    ui->gupr_elTableView->setModel(gupr_elTable);
    ui->guprTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    ui->gupr_elTableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
    ui->gupr_elTableView->hideColumn(0);
}

void Gupr::SetDB(QSqlDatabase _db)
{
    db = _db;
    Update();
}

void Gupr::Add()
{
    QSqlQuery query("select id_gupr_elem from gupr_elem where name_gupr_elem='" + formAdd->arg2 + "';");
    query.next();
    QString str = query.value(0).toString();/*
    int pos = str.lastIndexOf(QChar('"'));
    str = str.left(pos);
    pos = str.lastIndexOf(QChar('"'));
    str = str.right(pos);*/
   // qDebug() << str;
    db.exec("select insertintogupr(" + formAdd->arg1 + ", " + str + ")");
    guprTable->select();
    gupr_elTable->select();

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
    formAdd->Set("Длительность", "Курс", "Количество недель", "Элемент ГУПР");
    formAdd->SetInput(0, 0, 0, -1);
    formAdd->show();
}


void Gupr::on_delButton_clicked()
{
    QModelIndex ind;
    int row = ui->guprTableView->selectionModel()->selectedRows(0).first().row();
    qDebug() << row;
    guprTable->removeRow(row, ind);

    if(!guprTable->submitAll())
    {
        QMessageBox::critical(this, tr("ERROR!"), db.lastError().databaseText());
    }
}

