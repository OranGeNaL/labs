#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    mainMenu = new QMenu(tr("&Меню"), this);
    mainMenuTables = new QMenu(tr("&Основные таблицы"), this);
    otherMenuTables = new QMenu(tr("&Справочники"), this);

    actAuthorisation = new QAction(tr("&Авторизация"), this);

    actUch_Load = new QAction(tr("&Учебная нагрузка"), this);

    actCourse = new QAction(tr("&Курс"), this);
    actDiscipline = new QAction(tr("&Дисциплина"), this);
    actSpeciality = new QAction(tr("&Специальность"), this);
    actUch_Plan = new QAction(tr("&Учебный план"), this);
    actGruppa = new QAction(tr("&Группа"), this);
    actGupr = new QAction(tr("&ГУПР"), this);
    actGupr_elem = new QAction(tr("&Элемент ГУПР"), this);
    actKafedra = new QAction(tr("&Кафедра"), this);
    actKaf_Rasp = new QAction(tr("&Кафедра распределения"), this);
    actSemestr = new QAction(tr("&Семестр"), this);
    actNumber_Weeks = new QAction(tr("&Количество недель"), this);

    mainMenu->addAction(actAuthorisation);

    mainMenuTables->addAction(actUch_Load);
    mainMenuTables->addAction(actGruppa);
    mainMenuTables->addAction(actKaf_Rasp);

    otherMenuTables->addAction(actCourse);
    otherMenuTables->addAction(actDiscipline);
    otherMenuTables->addAction(actSpeciality);
    otherMenuTables->addAction(actUch_Plan);
    otherMenuTables->addAction(actGupr);
    otherMenuTables->addAction(actGupr_elem);
    otherMenuTables->addAction(actKafedra);
    otherMenuTables->addAction(actSemestr);
    otherMenuTables->addAction(actNumber_Weeks);

    ui->menubar->addMenu(mainMenu);
    ui->menubar->addMenu(mainMenuTables);
    ui->menubar->addMenu(otherMenuTables);

    formAutorization = new Authorization();
    formUch_Plan = new Uch_Plan(db);

    connect(formAutorization, SIGNAL(sendConnect()), this,
    SLOT(Connect()));
    connect(formAutorization, SIGNAL(sendDisconnect()),
    this, SLOT(Disconnect()));

    connect(ui->menubar, SIGNAL(triggered(QAction*)), this, SLOT(OpenF(QAction*)));
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::OpenF(QAction* a)
{
    qDebug() << const_hash(a->text().toStdString().c_str());
    switch (const_hash(a->text().toStdString().c_str())) {
        case 1105689965: formAutorization->show();
            break;
        case 3566738188: selectTable("course");
            break;
        case 34458455: selectTable("discipline");
            break;
        case 2821064468: selectTable("speciality");
            break;
        case 2581877950: selectTable("gupr_elem");
            break;
    case 1721633621:
        formUch_Plan->Update();
        formUch_Plan->show();
        break;
    case 1202426404:
        selectTable("kafedra");
        break;
    case 4111733963:
        selectTable("number_weeks");
        break;
    case 3415898536:
        selectTable("semestr");
        break;
        /*case 391431443: formDiscipline->show();
        break;
        case 2821064468: formSpec->show();
        break;
        case 3919113952: formDepart->show();
        break;
        case 155890075: formStream->show();
        break;*/
    }

}

void MainWindow::selectTable(QString nameTable)
{
    ui->tableView->show();
    table = new QSqlRelationalTableModel(0, db);
    table->setTable(nameTable);
    ui->tableView->setModel(table);
    ui->tableView->showColumn(0);
    ui->tableView->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);

    if(nameTable == "discipline")
    {
        table->setHeaderData(1, Qt::Horizontal, QObject::tr("Наименование дисциплины"), Qt::DisplayRole);
        ui->tableView->hideColumn(0);
    }

    else if(nameTable == "course")
    {
        table->setHeaderData(0, Qt::Horizontal, QObject::tr("Номер курса"), Qt::DisplayRole);
    }

    else if(nameTable == "number_weeks")
    {
        table->setHeaderData(0, Qt::Horizontal, QObject::tr("Количество недель"), Qt::DisplayRole);
    }

    else if(nameTable == "speciality")
    {
        table->setHeaderData(1, Qt::Horizontal, QObject::tr("Специальность"), Qt::DisplayRole);
    }

    else if(nameTable == "gupr_elem")
    {
        table->setHeaderData(1, Qt::Horizontal, QObject::tr("Элемент ГУПР"), Qt::DisplayRole);
    }

    else if(nameTable == "kafedra")
    {
        table->setHeaderData(1, Qt::Horizontal, QObject::tr("Кафедра"), Qt::DisplayRole);
        ui->tableView->hideColumn(0);
    }

    else if(nameTable == "semestr")
    {
        table->setHeaderData(0, Qt::Horizontal, QObject::tr("Семестр"), Qt::DisplayRole);
    }

    table->select();
    //ui->tableView->
}

unsigned MainWindow::const_hash(char const *input)
{
    return *input ?
    static_cast<unsigned int>(*input) + 33 * const_hash(input + 1) :
    5381;
}

void MainWindow::Connect()
{
    db = QSqlDatabase::addDatabase("QPSQL");
    db.setHostName(formAutorization->host);
    db.setPort(formAutorization->port);
    db.setDatabaseName("PABD");
    db.setUserName(formAutorization->user);
    db.setPassword(formAutorization->password);
    formAutorization->hide();
    if(!db.open())
        QMessageBox::critical(this, tr("ERROR!"),
        db.lastError().databaseText());
    else
    QMessageBox::information(this, tr("SUCCESS!"),
    tr("Соединение установлено! Выберите таблицу для работы"));
    model = new QSqlRelationalTableModel(0, db);
    ui->tableView->setModel(model);
}

void MainWindow::Disconnect()
{
    model = new QSqlRelationalTableModel(0, db);
    ui->tableView->setModel(model);
    db.close();
    formAutorization->hide();
}
