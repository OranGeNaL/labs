#pragma once

#include <JuceHeader.h>

//==============================================================================
/*
    This component lives inside our window, and this is where you should put all
    your controls and content.
*/

class Visitor
{
public:
    Visitor(int _id) : id(_id) {}
    ~Visitor() {};

    void setCameTime(float time) {
        //juce::Random r;
        //came_time = (-1.f / visitors_intencivity) * log2f(r.nextFloat()) + offset;
        came_time = time;
    };
    float getCameTime() const { return came_time; };

    void setServed(bool served) { is_served = served; }
    bool isServed() const { return is_served; }

    int getId() const { return id; }

    void setInvalid() { is_valid = false; }
    bool isValid() const { return is_valid; }

private:
    int id;
    float came_time = 0.f;
    bool is_served = false;
    bool is_valid = true;
};

enum ChannelType {
    Applications,
    Service,
    Waiting,
    Served,
    Refusal
};

class ChannelLine
{
public:
    ChannelLine(ChannelType chType) : type(chType) {}
    ~ChannelLine() {}

    void setAllTime(float time) { allTime = time; }
    void addToCurrentTime(float time) { currentTime += time; }
    ChannelType getType() const { return type; }

    bool getVisitorTime(int id, std::pair<float, float>* time) {

        if (visitors_history.find(id) != visitors_history.end()) {
            time->first = visitors_history.find(id)->second.first;
            time->second = visitors_history.find(id)->second.second;
            return true;
        }
        return false;
    }

    bool getLastVisitorTime(std::pair<float, float>* time) {
        if (!busy_sections.empty()) {
            time->first = busy_sections.back().first;
            time->second = busy_sections.back().second;
            return true;
        }
        return false;
    }

    float getAmountOfVisitors(float time_limitation) {
        float sum = 0;

        auto iterator = visitors_history.begin();
        while (iterator != visitors_history.end()) {
            if (iterator->second.first <= time_limitation) {
                ++sum;
            }
            ++iterator;
        }

        return sum;
    }

    float getFreeTime(float time_limitation) {
        float sum = 0;
        if (!busy_sections.empty()) {
            for (auto t : busy_sections) {
                if ((t.first + t.second) > time_limitation) {
                    sum += time_limitation - t.first;
                }
                else {
                    sum += t.second;
                }
            }
        }
        return time_limitation - sum;
    }

    bool setVisitor(Visitor& v, float ch_throughput, float time_to_wait = 0.f)
    {
        juce::Random r;
        float time;
        if (time_to_wait == 0.f) {
            time = (-1.f / ch_throughput) * std::logf(r.nextFloat());
            //time = 2.f;
        }
        else {
            time = time_to_wait;
        }
        
        std::pair<float, float> t(v.getCameTime(), 0.f);

        bool busy_flag = false;
        if (!busy_sections.empty()) {
            busy_flag = (v.getCameTime() < (busy_sections.back().first + busy_sections.back().second));
        } 

        if (visitors_history.find(v.getId()) == visitors_history.end() && !busy_flag) {
            

            switch (type)
            {
            case Applications:
                visitors_history.emplace(v.getId(), t);
                return true;
            case Service:
                if (!v.isServed()) {
                    t.second = time;
                    visitors_history.emplace(v.getId(), t);
                    busy_sections.push_back(t);
                    v.setCameTime(v.getCameTime() + time);
                    v.setServed(true);
                    return true;
                }
                break;
            case Waiting:
                if (!v.isServed()) {
                    t.second = time;
                    visitors_history.emplace(v.getId(), t);
                    busy_sections.push_back(t);
                    v.setCameTime(v.getCameTime() + time);
                    return true;
                }
                break;
            case Served:
                if (v.isServed()) {
                    visitors_history.emplace(v.getId(), t);
                    v.setInvalid();
                    return true;
                }
                break;
            case Refusal:
                if (!v.isServed()) {
                    visitors_history.emplace(v.getId(), t);
                    v.setInvalid();
                    return true;
                }
                break;
            default:
                break;
            }
        }

        return false;
    }
private:
    ChannelType type;
    float allTime = 1.f;
    float currentTime = 0.f;
    std::map<int, std::pair<float, float>> visitors_history;
    std::vector<std::pair<float, float>> busy_sections;
};

struct InputData
{
    int clients_intencivity;
    int amount_of_clients;
    int filst_throughput;
    int second_throughput;
    int wainting_places_amount;
    float time_of_view;
    std::map<juce::String, ChannelLine> channels;
    juce::StringArray channelNames;
};

struct GraphicsComponent : juce::Component
{
public:
    GraphicsComponent();
    ~GraphicsComponent();

    void paint(juce::Graphics& g) override;
    void resized() override;
    void mouseWheelMove(const juce::MouseEvent& event, const juce::MouseWheelDetails& wheel) override;

    //juce::Rectangle<int> getBounds();
    void setMaxSize(int w, int h) { max_width = w; max_height = h; current_scale = 1.f; setSize(max_width, max_height); };
    void setupBackground();
    void setData(InputData data) { inputData = data; }
    juce::Path makeVisitorPath(int id);
    void generateColours(int amount);

private:
    juce::Image background;
    float scale = 1.f;

    InputData inputData;

    std::vector<juce::Colour> v_colours;

    int max_width = 1000;
    int max_height = 1000;
    float current_scale = 1.f;
};

struct GraphicViewport : juce::Viewport
{
    GraphicViewport();
    ~GraphicViewport();

    void mouseDrag(const juce::MouseEvent& event) override;
};

class MainComponent  : public juce::AnimatedAppComponent
{
public:
    MainComponent();
    ~MainComponent() override;

    void update() override;
    void paint (juce::Graphics& g) override;
    void resized() override;

    void calculateValues();

private:
    GraphicViewport graphicViewport;
    GraphicsComponent graphic;

    juce::Label intensivity_label;
    juce::TextEditor intensivity_editor;

    juce::Label first_th_label;
    juce::TextEditor first_th_editor;

    juce::Label second_th_label;
    juce::TextEditor second_th_editor;

    juce::Label view_time_label;
    juce::TextEditor view_time_editor;

    //juce::Label am_of_waiting_places_label;
    //juce::TextEditor am_of_waiting_places_editor;

    juce::TextButton calculateButton;

    juce::Label av_syst_th_label;
    juce::Label av_syst_th_edit_label;

    juce::Label serv_likelihood_label;
    juce::Label serv_likelihood_edit_label;

    juce::Label discard_likelihood_label;
    juce::Label discard_likelihood_edit_label;

    juce::Label first_hold_likelihood_label;
    juce::Label first_hold_likelihood_edit_label;

    juce::Label second_hold_likelihood_label;
    juce::Label second_hold_likelihood_edit_label;

    JUCE_DECLARE_NON_COPYABLE_WITH_LEAK_DETECTOR(MainComponent)
};
