/****************************************************************************
** Meta object code from reading C++ file 'kaf_rasp.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.15.2)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include <memory>
#include "../l5_program/kaf_rasp.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'kaf_rasp.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.15.2. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
struct qt_meta_stringdata_Kaf_Rasp_t {
    QByteArrayData data[9];
    char stringdata0[145];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_Kaf_Rasp_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_Kaf_Rasp_t qt_meta_stringdata_Kaf_Rasp = {
    {
QT_MOC_LITERAL(0, 0, 8), // "Kaf_Rasp"
QT_MOC_LITERAL(1, 9, 3), // "Add"
QT_MOC_LITERAL(2, 13, 0), // ""
QT_MOC_LITERAL(3, 14, 7), // "Dismiss"
QT_MOC_LITERAL(4, 22, 20), // "on_addButton_clicked"
QT_MOC_LITERAL(5, 43, 20), // "on_delButton_clicked"
QT_MOC_LITERAL(6, 64, 35), // "on_kafedraCombo_currentIndexC..."
QT_MOC_LITERAL(7, 100, 5), // "index"
QT_MOC_LITERAL(8, 106, 38) // "on_specialityCombo_currentInd..."

    },
    "Kaf_Rasp\0Add\0\0Dismiss\0on_addButton_clicked\0"
    "on_delButton_clicked\0"
    "on_kafedraCombo_currentIndexChanged\0"
    "index\0on_specialityCombo_currentIndexChanged"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_Kaf_Rasp[] = {

 // content:
       8,       // revision
       0,       // classname
       0,    0, // classinfo
       6,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: name, argc, parameters, tag, flags
       1,    0,   44,    2, 0x08 /* Private */,
       3,    0,   45,    2, 0x08 /* Private */,
       4,    0,   46,    2, 0x08 /* Private */,
       5,    0,   47,    2, 0x08 /* Private */,
       6,    1,   48,    2, 0x08 /* Private */,
       8,    1,   51,    2, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void, QMetaType::Int,    7,
    QMetaType::Void, QMetaType::Int,    7,

       0        // eod
};

void Kaf_Rasp::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        auto *_t = static_cast<Kaf_Rasp *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->Add(); break;
        case 1: _t->Dismiss(); break;
        case 2: _t->on_addButton_clicked(); break;
        case 3: _t->on_delButton_clicked(); break;
        case 4: _t->on_kafedraCombo_currentIndexChanged((*reinterpret_cast< int(*)>(_a[1]))); break;
        case 5: _t->on_specialityCombo_currentIndexChanged((*reinterpret_cast< int(*)>(_a[1]))); break;
        default: ;
        }
    }
}

QT_INIT_METAOBJECT const QMetaObject Kaf_Rasp::staticMetaObject = { {
    QMetaObject::SuperData::link<QDialog::staticMetaObject>(),
    qt_meta_stringdata_Kaf_Rasp.data,
    qt_meta_data_Kaf_Rasp,
    qt_static_metacall,
    nullptr,
    nullptr
} };


const QMetaObject *Kaf_Rasp::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *Kaf_Rasp::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_Kaf_Rasp.stringdata0))
        return static_cast<void*>(this);
    return QDialog::qt_metacast(_clname);
}

int Kaf_Rasp::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QDialog::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 6)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 6;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 6)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 6;
    }
    return _id;
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE
