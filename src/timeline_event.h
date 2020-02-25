// Copyright 2014 Toggl Desktop developers.

#ifndef SRC_TIMELINE_EVENT_H_
#define SRC_TIMELINE_EVENT_H_

#include <time.h>

#include <sstream>
#include <string>

#include "base_model.h"
#include "formatter.h"

namespace toggl {

class TOGGL_INTERNAL_EXPORT TimelineEvent : public BaseModel, public TimedEvent {
    TimelineEvent(ProtectedBase *container)
        : BaseModel(container)
    , title_("")
    , filename_("")
    , start_time_(0)
    , end_time_(0)
    , duration_(0)
    , idle_(false)
    , chunked_(false)
    , uploaded_(false) {}
public:
    friend class ProtectedBase;

    virtual ~TimelineEvent() {}

    const std::string &Title() const {
        return title_;
    }
    void SetTitle(const std::string &value);

    const Poco::Int64 &Start() const  override{
        return start_time_;
    }
    void SetStart(const Poco::Int64 value);

    const Poco::Int64 &EndTime() const {
        return end_time_;
    }
    void SetEndTime(const Poco::Int64 value);

    const Poco::Int64 &Duration() const {
        return duration_;
    }

    const bool &Idle() const {
        return idle_;
    }
    void SetIdle(const bool value);

    const std::string &Filename() const {
        return filename_;
    }
    void SetFilename(const std::string &value);

    const bool &Chunked() const {
        return chunked_;
    }
    void SetChunked(const bool value);

    const bool &Uploaded() const {
        return uploaded_;
    }
    void SetUploaded(const bool value);

    bool VisibleToUser() const {
        return !Uploaded() && !DeletedAt() && Chunked();
    }

    // Override BaseModel

    std::string String() const override;
    std::string ModelName() const override;
    std::string ModelURL() const override;
    Json::Value SaveToJSON() const override;

 private:
    std::string title_;
    std::string filename_;
    Poco::Int64 start_time_;
    Poco::Int64 end_time_;
    Poco::Int64 duration_;
    bool idle_;
    bool chunked_;
    bool uploaded_;

    void updateDuration();
};

}  // namespace toggl

#endif  // SRC_TIMELINE_EVENT_H_
