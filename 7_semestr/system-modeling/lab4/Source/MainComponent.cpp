#include "MainComponent.h"

GraphicsComponent::GraphicsComponent() : juce::Component()
{
    setSize(max_width, max_height);
}

GraphicsComponent::~GraphicsComponent()
{

}

void GraphicsComponent::setupBackground() {
    static const int font_height = 19;
    static const int smaller_font_height = 14;
    static const int smallest_font_height = 10;
    using namespace juce;

    background = Image(Image::PixelFormat::RGB, getWidth(), getHeight(), true);
    Graphics g(background);
    g.setColour(Colours::white);
    g.fillAll();

    if (!inputData.channelNames.isEmpty()) {
        generateColours(inputData.amount_of_clients);

        int max_font_width = 0;
        for (juce::String str : inputData.channelNames) {
            max_font_width = jmax(g.getCurrentFont().getStringWidth(str), max_font_width);
        }
        max_font_width += font_height * 2;

        int horizontal_lines = getHeight() / (inputData.channelNames.size() + 1);

        Rectangle<float> r;
        g.setColour(Colours::black);
        g.drawLine(max_font_width + font_height, 0, max_font_width + font_height, getHeight(), 2);

        int time_width = (getWidth() - (max_font_width + font_height)) * 0.9f;
        float big_intervals = float(time_width) / inputData.time_of_view;
        float small_intervals = big_intervals / 10.f;

        std::vector<std::vector<std::tuple<float, float, float>>> for_vertical_lines;


        for (int i = 1; i <= inputData.channelNames.size(); ++i) {
            g.setColour(Colours::black);
            int x = max_font_width + font_height;
            int x_off = x + 20;
            int y = i * horizontal_lines;

            g.setFont(font_height);
            r.setSize(max_font_width, font_height);
            r.setCentre(max_font_width / 2.f, y);
            g.drawFittedText(inputData.channelNames[i - 1], r.toNearestInt(), Justification::right, 1);

            g.setColour(Colours::red);
            g.drawLine(x, y, getWidth(), y, 1.f);
            g.setColour(Colours::black);

            
            for (int j = 0; j < inputData.time_of_view; ++j) {
                g.drawVerticalLine(x_off + j * big_intervals, y - 5, y + 5);
                g.setFont(smaller_font_height);
                juce::String str(j);
                r.setSize(g.getCurrentFont().getStringWidth(str), smaller_font_height);
                r.setCentre(x_off + j * big_intervals, y + 6 + smaller_font_height / 2);
                g.drawFittedText(str, r.toNearestInt(), Justification::centred, 1);
                g.setFont(smallest_font_height);
                for (int k = 1; k < 10; ++k) {
                    if (big_intervals > 150.f) {
                        juce::String str1("0.");
                        str1.append(juce::String(k), 10);
                        r.setSize(g.getCurrentFont().getStringWidth(str1), smallest_font_height);
                        r.setCentre(x_off + j * big_intervals + k * small_intervals, y + 4 + smallest_font_height / 2);
                        g.drawFittedText(str1, r.toNearestInt(), Justification::centred, 1);
                    }
                    g.drawVerticalLine(x_off + j * big_intervals + k * small_intervals, y - 2, y + 2);
                }
            }

            const float dots[2] = { 4, 5 };
            juce::Line<float> dottedLine;
            dottedLine.setStart(x_off + inputData.time_of_view * big_intervals, 0);
            dottedLine.setEnd(x_off + inputData.time_of_view * big_intervals, getHeight());
            g.drawDashedLine(dottedLine, dots, 2);
            g.setFont(smaller_font_height);
            juce::String str(inputData.time_of_view);
            r.setSize(g.getCurrentFont().getStringWidth(str), smaller_font_height);
            r.setCentre(x_off + inputData.time_of_view * big_intervals + smaller_font_height / 2, y + 6 + smaller_font_height / 2);
            g.drawFittedText(str, r.toNearestInt(), Justification::centred, 1);




            
            std::pair<float, float>* time = new std::pair<float, float>(0, 0);
            std::vector<std::tuple<float, float, float>> ch_times;
            
            for (int v = 0; v < inputData.amount_of_clients; ++v) {
                std::tuple<float, float, float> p(std::make_tuple(0.f, 0.f, 0.f));
                if (inputData.channels.find(inputData.channelNames[i - 1])->second.getVisitorTime(v, time)) {
                    float x_1 = x_off + big_intervals * time->first;
                    float x_2 = x_off + big_intervals * (time->first + time->second);
                    std::get<0>(p) = x_1;
                    std::get<1>(p) = x_2;
                    std::get<2>(p) = y;
                    
                    g.setColour(v_colours[v]);

                    if (time->second == 0.f) {
                        int radius = 5;
                        Rectangle<float> r;
                        r.setBounds(x_1 - radius, y - radius, radius * 2, radius * 2);
                        g.fillEllipse(r);

                        r.setCentre(r.getX() - radius, r.getY() - radius);
                        g.drawFittedText(String(v + 1), r.toNearestInt(), Justification::centred, 1);
                    }
                    else {
                        g.drawLine(x_1, y, x_2, y, 5);
                    }
                }
                ch_times.push_back(p);
            }
            for_vertical_lines.push_back(ch_times);
            delete time;
        }

        for (int k = 0; k < inputData.amount_of_clients; ++k) {
            std::vector < std::tuple<float, float, float> > walkthrow;

            float max_value = 0.f;
            float min_value = std::get<0>(for_vertical_lines[0][k]);
            for (int n = 0; n < for_vertical_lines.size(); ++n) {
                max_value = juce::jmax(max_value, std::get<0>(for_vertical_lines[n][k]));
            }

            bool done_flag = false;
            while (!done_flag) {
                for (int l = 0; l < for_vertical_lines.size(); ++l) {
                    if (std::get<0>(for_vertical_lines[l][k]) != 0.f && std::get<0>(for_vertical_lines[l][k]) == min_value) {
                        walkthrow.push_back(for_vertical_lines[l][k]);
                        min_value = std::get<1>(for_vertical_lines[l][k]);
                        if (min_value == max_value) {
                            done_flag = true;
                        }
                    }
                }
            }
            
            g.setColour(v_colours[k]);
            for (int m = 1; m < walkthrow.size(); ++m) {
                g.drawLine(std::get<1>(walkthrow[m - 1]), std::get<2>(walkthrow[m - 1]), std::get<0>(walkthrow[m]), std::get<2>(walkthrow[m]));
            }
        }
    }      
}

void GraphicsComponent::generateColours(int amount) {
    juce::Random r;
    r.setSeed(4);
    for (int i = 0; i < amount; ++i) {
        juce::Colour c;
        bool done_flag = false;
        while (!done_flag) {
            std::tuple<float, float, float> t(r.nextFloat(), r.nextFloat(), r.nextFloat());
            if (std::get<1>(t) > 0.7f && std::get<2>(t) > 0.5f) {
                done_flag = true;
                c = juce::Colour(std::get<0>(t), std::get<1>(t), std::get<2>(t), 0.9f);
            }
        }
        v_colours.push_back(c);
    }
}

juce::Path GraphicsComponent::makeVisitorPath(int id) {
    juce::Path p;

    

    return p;
}

void GraphicsComponent::paint(juce::Graphics& g) {
    if(background.isValid())
        g.drawImage(background, getLocalBounds().toFloat());  
}

void GraphicsComponent::mouseWheelMove(const juce::MouseEvent& event, const juce::MouseWheelDetails& wheel) {
    if (wheel.deltaY > 0) {
        current_scale += 0.1f;
    }
    else if(current_scale > 1.f) {
        current_scale -= 0.1f;
    }
        
    setSize(max_width * current_scale, max_height * current_scale);    
}

void GraphicsComponent::resized() {
    setupBackground();
}
//==============================================================================
GraphicViewport::GraphicViewport() : juce::Viewport()
{
}

GraphicViewport::~GraphicViewport() {
}

void GraphicViewport::mouseDrag(const juce::MouseEvent& event) {
}


//==============================================================================
void MainComponent::calculateValues() {
    InputData inputData;

    inputData.clients_intencivity = intensivity_editor.getText().getIntValue();
    inputData.filst_throughput = first_th_editor.getText().getIntValue();
    inputData.second_throughput = second_th_editor.getText().getIntValue();
    inputData.time_of_view = view_time_editor.getText().getIntValue();
    //inputData.wainting_places_amount = am_of_waiting_places_editor.getText().getIntValue();
    inputData.wainting_places_amount = 2;

    inputData.channelNames.clear();
    inputData.channels.clear();

    inputData.channelNames.add("Applications");
    ChannelLine appLine(ChannelType::Applications);
    inputData.channels.emplace("Applications", appLine);

    inputData.channelNames.add("1 channel");
    ChannelLine fChLine(ChannelType::Service);
    inputData.channels.emplace("1 channel", fChLine);

    inputData.channelNames.add("2 channel");
    ChannelLine sChLine(ChannelType::Service);
    inputData.channels.emplace("2 channel", sChLine);
    int waiting_channels = 1;
    for (waiting_channels = 1; waiting_channels <= inputData.wainting_places_amount; ++waiting_channels) {
        juce::String str(waiting_channels);
        str.append(" place", 10);
        inputData.channelNames.add(str);
        ChannelLine wLine(ChannelType::Waiting);
        inputData.channels.emplace(str, wLine);
    }
    inputData.channelNames.add("Served");
    ChannelLine sLine(ChannelType::Served);
    inputData.channels.emplace("Served", sLine);

    inputData.channelNames.add("Refusal");
    ChannelLine rLine(ChannelType::Refusal);
    inputData.channels.emplace("Refusal", rLine);

    std::vector<Visitor> v_list;
    float offset = 0.f;
    int i = 0;
    //for (int i = 0; i < inputData.clients_intencivity; ++i) {
    while(offset < inputData.time_of_view){
        Visitor v(i);
        ++i;

        v.setCameTime(offset);
        juce::Random r;
        float rand_num = (-1.f / inputData.clients_intencivity) * std::logf(r.nextFloat() * 0.5);
        offset += rand_num;
        //DBG(rand_num);

        v_list.push_back(v);
        inputData.channels.find("Applications")->second.setVisitor(v, inputData.clients_intencivity);
    }
    inputData.amount_of_clients = v_list.size();

    for (int v = 0; v < v_list.size(); ++v) { // по всем посетителям
        while (v_list[v].isValid()) { // пока посетитель не обслужен или ему не отказано в обс
            for (int ch = 1; ch < inputData.channelNames.size(); ++ch) { // по всем каналам
                if (inputData.channels.find(inputData.channelNames[ch])->second.getType() == ChannelType::Waiting) { // если канал для ожидания
                    float min_time = inputData.time_of_view; // находим мин время ожидания
                    for (int c_pred = 1; c_pred < ch; ++c_pred) {// проходом по всем предыдущим каналам
                        std::pair<float, float>* t = new std::pair<float, float>(0.f, 0.f);
                        if (inputData.channels.find(inputData.channelNames[c_pred])->second.getLastVisitorTime(t)) {
                            min_time = juce::jmin(min_time, t->first + t->second);
                        }
                        delete t;
                    }
                    if (inputData.channels.find(inputData.channelNames[ch])->second.setVisitor(v_list[v], inputData.clients_intencivity, min_time - v_list[v].getCameTime())) {
                        break;
                    }
                }
                else {
                    float th = 5.f;
                    if (inputData.channelNames[ch] == "1 channel") {
                        th = inputData.filst_throughput;
                    }
                    else if (inputData.channelNames[ch] == "2 channel") {
                        th = inputData.second_throughput;
                    }

                    if (inputData.channels.find(inputData.channelNames[ch])->second.setVisitor(v_list[v], th)) {
                        break;
                    }
                }  
            }
        }
    }

    //DBG(inputData.channels.find("Served")->second.getAmountOfVisitors(inputData.time_of_view));
    float av_syst_th = inputData.channels.find("Served")->second.getAmountOfVisitors(inputData.time_of_view) / inputData.time_of_view;
    av_syst_th_edit_label.setText(juce::String(av_syst_th), juce::NotificationType::dontSendNotification);

    float serv_likelihood = inputData.channels.find("Served")->second.getAmountOfVisitors(inputData.time_of_view) / inputData.channels.find("Applications")->second.getAmountOfVisitors(inputData.time_of_view);
    serv_likelihood_edit_label.setText(juce::String(serv_likelihood), juce::NotificationType::dontSendNotification);

    float discard_likelihood = inputData.channels.find("Refusal")->second.getAmountOfVisitors(inputData.time_of_view) / inputData.channels.find("Applications")->second.getAmountOfVisitors(inputData.time_of_view);
    discard_likelihood_edit_label.setText(juce::String(discard_likelihood), juce::NotificationType::dontSendNotification);

    //DBG(inputData.channels.find("1 channel")->second.getFreeTime(inputData.time_of_view));
    float first_hold_likelihood = inputData.channels.find("1 channel")->second.getFreeTime(inputData.time_of_view) / inputData.time_of_view;
    first_hold_likelihood_edit_label.setText(juce::String(first_hold_likelihood), juce::NotificationType::dontSendNotification);

    float second_hold_likelihood = inputData.channels.find("2 channel")->second.getFreeTime(inputData.time_of_view) / inputData.time_of_view;
    second_hold_likelihood_edit_label.setText(juce::String(second_hold_likelihood), juce::NotificationType::dontSendNotification);

    DBG("--------");
    graphic.setData(inputData);
    graphic.setupBackground();
}

MainComponent::MainComponent()
{
    graphicViewport.setViewedComponent(&graphic);
    graphicViewport.setScrollBarThickness(20);
    addAndMakeVisible(graphicViewport);

    intensivity_label.setText("Customer flow intensity", juce::NotificationType::dontSendNotification); // Интенсивность потока клиентов
    intensivity_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(intensivity_label);
    intensivity_editor.setText("5");
    intensivity_editor.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(intensivity_editor);

    first_th_label.setText("First channel throughput", juce::NotificationType::dontSendNotification); // пропускная способность первого канала
    first_th_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(first_th_label);
    first_th_editor.setText("1");
    first_th_editor.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(first_th_editor);

    second_th_label.setText("Second channel throughput", juce::NotificationType::dontSendNotification); // пропускная способность второго канала
    second_th_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(second_th_label);
    second_th_editor.setText("2");
    second_th_editor.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(second_th_editor);

    view_time_label.setText("Observation time", juce::NotificationType::dontSendNotification); // время наблюдения
    view_time_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(view_time_label);
    view_time_editor.setText("5");
    view_time_editor.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(view_time_editor);

    //am_of_waiting_places_label.setText("Number of waiting places", juce::NotificationType::dontSendNotification); // Количество мест ожидания
    //addAndMakeVisible(am_of_waiting_places_label);
    //am_of_waiting_places_editor.setText("2");
    //addAndMakeVisible(am_of_waiting_places_editor);

    calculateButton.setButtonText("Calculate");
    calculateButton.onClick = [this] { calculateValues(); };
    addAndMakeVisible(calculateButton);

    av_syst_th_label.setText("Average system throughput", juce::NotificationType::dontSendNotification); // средняя пропускная способность системы
    av_syst_th_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(av_syst_th_label);
    av_syst_th_edit_label.setText("0", juce::NotificationType::dontSendNotification);
    av_syst_th_edit_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(av_syst_th_edit_label);

    serv_likelihood_label.setText("Customer service likelihood", juce::NotificationType::dontSendNotification); // вероятность обслуживания клиента
    serv_likelihood_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(serv_likelihood_label);
    serv_likelihood_edit_label.setText("0", juce::NotificationType::dontSendNotification);
    serv_likelihood_edit_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(serv_likelihood_edit_label);

    discard_likelihood_label.setText("Denial of service probability", juce::NotificationType::dontSendNotification); // вероятность отказа в обслуживании
    discard_likelihood_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(discard_likelihood_label);
    discard_likelihood_edit_label.setText("0", juce::NotificationType::dontSendNotification);
    discard_likelihood_edit_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(discard_likelihood_edit_label);

    first_hold_likelihood_label.setText("First column downtime probability", juce::NotificationType::dontSendNotification); // вероятность простоя первой колонки
    first_hold_likelihood_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(first_hold_likelihood_label);
    first_hold_likelihood_edit_label.setText("0", juce::NotificationType::dontSendNotification);
    first_hold_likelihood_edit_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(first_hold_likelihood_edit_label);

    second_hold_likelihood_label.setText("Second column downtime probability", juce::NotificationType::dontSendNotification); // вероятность простоя второй колонки
    second_hold_likelihood_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(second_hold_likelihood_label);
    second_hold_likelihood_edit_label.setText("0", juce::NotificationType::dontSendNotification);
    second_hold_likelihood_edit_label.setColour(juce::Label::textColourId, juce::Colours::black);
    addAndMakeVisible(second_hold_likelihood_edit_label);

    setSize(800, 600);
    setFramesPerSecond(30);
}

MainComponent::~MainComponent()
{
}

void MainComponent::update()
{

}

void MainComponent::paint (juce::Graphics& g)
{   
    //g.fillAll (getLookAndFeel().findColour (juce::ResizableWindow::backgroundColourId));
    g.fillAll(juce::Colours::white);

    auto x = getLocalBounds().removeFromLeft(299).getWidth();
    
    g.setColour(juce::Colours::black);
    g.drawVerticalLine(x, 0, getHeight());
}

void MainComponent::resized()
{
    static const int interface_width = 300;
    static const int labels_width = 250;
    static const int labels_height = 20;
    static const int padding = 5;

    auto bounds = getLocalBounds();
    auto interface_bounds = bounds.removeFromLeft(interface_width);

    graphicViewport.setBounds(bounds);
    graphic.setMaxSize(graphicViewport.getWidth(), graphicViewport.getHeight());

    interface_bounds.removeFromTop(padding);
    
    auto intensivity_bounds = interface_bounds.removeFromTop(labels_height);
    intensivity_label.setBounds(intensivity_bounds.removeFromLeft(labels_width));
    intensivity_bounds.removeFromRight(padding);
    intensivity_editor.setBounds(intensivity_bounds);

    interface_bounds.removeFromTop(padding);

    auto first_th_bounds = interface_bounds.removeFromTop(labels_height);
    first_th_label.setBounds(first_th_bounds.removeFromLeft(labels_width));
    first_th_bounds.removeFromRight(padding);
    first_th_editor.setBounds(first_th_bounds);

    interface_bounds.removeFromTop(padding);

    auto second_th_bounds = interface_bounds.removeFromTop(labels_height);
    second_th_label.setBounds(second_th_bounds.removeFromLeft(labels_width));
    second_th_bounds.removeFromRight(padding);
    second_th_editor.setBounds(second_th_bounds);

    interface_bounds.removeFromTop(padding);

    auto view_time_bounds = interface_bounds.removeFromTop(labels_height);
    view_time_label.setBounds(view_time_bounds.removeFromLeft(labels_width));
    view_time_bounds.removeFromRight(padding);
    view_time_editor.setBounds(view_time_bounds);

    interface_bounds.removeFromTop(padding);

    //auto am_of_waiting_places_bounds = interface_bounds.removeFromTop(labels_height);
    //am_of_waiting_places_label.setBounds(am_of_waiting_places_bounds.removeFromLeft(labels_width));
    //am_of_waiting_places_bounds.removeFromRight(padding);
    //am_of_waiting_places_editor.setBounds(am_of_waiting_places_bounds);

    interface_bounds.removeFromTop(padding);

    auto calculate_bounds = interface_bounds.removeFromTop(labels_height);
    calculate_bounds.removeFromLeft(padding);
    calculate_bounds.removeFromRight(padding);
    calculateButton.setBounds(calculate_bounds);

    interface_bounds.removeFromTop(padding);

    auto av_syst_th_bounds = interface_bounds.removeFromBottom(labels_height);
    av_syst_th_label.setBounds(av_syst_th_bounds.removeFromLeft(labels_width));
    av_syst_th_edit_label.setBounds(av_syst_th_bounds);

    interface_bounds.removeFromTop(padding);

    auto serv_likelihood_bounds = interface_bounds.removeFromBottom(labels_height);
    serv_likelihood_label.setBounds(serv_likelihood_bounds.removeFromLeft(labels_width));
    serv_likelihood_edit_label.setBounds(serv_likelihood_bounds);

    interface_bounds.removeFromTop(padding);

    auto discard_likelihood_bounds = interface_bounds.removeFromBottom(labels_height);
    discard_likelihood_label.setBounds(discard_likelihood_bounds.removeFromLeft(labels_width));
    discard_likelihood_edit_label.setBounds(discard_likelihood_bounds);

    interface_bounds.removeFromTop(padding);

    auto first_hold_likelihood_bounds = interface_bounds.removeFromBottom(labels_height);
    first_hold_likelihood_label.setBounds(first_hold_likelihood_bounds.removeFromLeft(labels_width));
    first_hold_likelihood_edit_label.setBounds(first_hold_likelihood_bounds);

    interface_bounds.removeFromTop(padding);

    auto second_hold_likelihood_bounds = interface_bounds.removeFromBottom(labels_height);
    second_hold_likelihood_label.setBounds(second_hold_likelihood_bounds.removeFromLeft(labels_width));
    second_hold_likelihood_edit_label.setBounds(second_hold_likelihood_bounds);
}
